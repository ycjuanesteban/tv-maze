# TV MAZE

Esta api permite hacer una llamada al api de tvmaze y la respuesta la almacena en una base de datos local para su posterior extracción.

La solución está dividida de la siguiente manera:

* iac 
  * docker-compose
  * dockerfile  
* src
  * host
  * api
  * application
  * domain
  * data
  * http client
  * auth (ver la nota)
* tests
  * tests

## Explicación del proyecto

`Palabras clave: SOLID, Clean Architecture, NoSQL, CQRS, MediatR`

El proyecto está dividido en capas y cada una tiene una única responsabilidad y soluciona un problema específico, esto apoyado en los principios SOLID ayuda a que se tengan claras las responsabilidades de cada proyecto.

La libería de dominio es la que contiene las clases que representan la información de los show de televisión que se almacenaran en la base de datos. Además presenta abstracciones que permiten tener accedo a los datos, esto permite que cualquier librería a futuro que implemente la interface `IShowMainInformationRepository` exponga los mismos método (commands y queries) y así se genera un estandar para toda la aplicación y garantiza la correcta aplicación de la inversión de control y el principio de segregación de interfaces.

La librería de data implementa la interface `IShowMainInformationRepository` para proveer el acceso a la base de datos.
Esta es la capa que usa el driver de mongo para crear la conexión y usar esta para extraer y almacenar datos.
Se usa mongodb como base de datos en vez de una base de datos relacional porque, al momento de analizar los datos que proporciona el api de TvMaze, se puede evidenciar que estos son una agrupación jerárquica y semi estructurada de datos, además al revisar los datos de los personajes, estos en ocasiones vendrian o no dependiendo del flag encargado de dicha extracción y esto lleva a que este conjunto de datos exista o no dependiendo de cada caso. 

Con todo esto en mente, decidí usar una base de datos documetal porque me permite tener esta información que cambia con el tiempo y almacenada como una unidad y que se puede consultar con facilidad y evitar joins y agregados que unan la información.

La librería de aplicación es la que tiene toda la lógica de negocio asociada. Aquí se ve claramente la separación de los comandos y las queries y para esto usé la librería MediatR que de una forma fácil y gracias a sus Handlers permite aplicar el patron `mediator` y así desacoplar los llamados a manejadores directos y reducir sus dependencias directas.

Además de esto se creo un evento que permite almacenar la información cuando se obtiene desde el api de TvMaze. Esto con el fin de independizar este guardado (command) de la obtención (query) de la información. Para esto, y con la ayuda de MediatR publiqué el evento de guardado y su handler correspondiente maneja esta lógica. 

Adicional a esto, usé Automapper para facilitar el mapeo de los dtos a objetos de dominio y viceversa.

La librería del cliente HTTP es la que se encarga del llamado al api de TvMaze, esta libería implementa la interface `ITvMazeServiceClient` que provee la libería de los contratos. Con este proyecto se busca el desacoplar completamente la aplicación de toda la lógica que implica hacer un llamado y validar su respuesta.

La librería de contratos es la que provee al sistema de los dtos.

La librería api es la que implementa los controladores que se exponen al público y es la que se encarga de configurar, gracias a la extensión `ConfigureAppiServices` que usa `IServiceCollection`, los repositorios, la autenticación, la librería de MediatR y Automapper y finalmente el cliente HTTP.

Esta librería es la que une todos los componentes que contienen lógica y es el punto de ingreso para la aplicación.

Finalmente la librería de Host es la que configura los servicios que no tienen nada que ver con la aplicaciones como lo es swagger, la autenticación (el servicio que expone Microsoft con sus plugins para securizar la aplicación al completo), y es quien ejecuta la aplicación.

## Inicio de la aplicación
Para iniciar la aplicación es necesario ir a la carpeta `iac` y ejecutar el comando
```
  docker-compose up
```
Con la ejecución de este comando, se iniciaran los servicios de base de datos y el api.
La url por la cual se pueden consultar los datos y hacer llamados al api de tvmaze es http://localhost:4200/swagger

El proceso para hacer una ejecución completa es el siguiente:

1. Hacer login. En este momento el usuario es `UserName01` y la clave es `UserName01`
2. Hacer un llamado al endpoint `/api/external-information` el cual consultará al api de tvmaze y, al recibir la respuesta, guardará los datos en la base de datos y finalmente mostrará el show seleccionado. 

    Un ejemplo de un llamado sería el siguiente `/api/external-information?ShowId=2&WithEmbedCast=false`
3. Hacer un llamado al endpoint `/api/local-information` el cual devolverá toda la información almacenada en la base de datos.


Si se quiere cambiar la configuración del usuario y la clave se puede hacer modificando el archivo docker-compose como se indica a continuación:

```
services:
  ...
  tv-maze-api:
    ...
    environment:
      ...
      - TvMazeAuthConfiguration__UserName=NEW_USER_NAME
      - TvMazeAuthConfiguration__Password=NEW_PASSWORD
```
Finalmente si desea ejecutar la aplicación desde visual studio, es necesario que exista una instancia de mongodb en ejecución y además es importante, si así lo requiere, hacer una actualización de la cadena de conexión para dicha base de datos.

Este dato se puede cambiar en el archivo `appsettings.json` que se encuentra en el proyecto `src/TvMaze.Api.Host`

```
{
  ...
  "TvMazeContextConfigOptions": {
    "ConnectionString": "mongodb://localhost:27017",
    ...
  }
}
```

## Nota: 
 
El servicio de auth es algo similar a un servicio mock. Este responderá con un token JWT para simular un llamado a un servicio de login tipo IdS o AAD.

El foco principal del problema a resolver no es crear un servicio de autenticación y autorización, para esto existen programas y plataformas específicas.

Por favor, no tener en cuenta la librería de Auth ya que esta es solo un método para devolver un token y no tiene un control total de la seguridad como lo pueden tener un Identity Server, un Azure Active Directory o cualquier otro servicio de Indentidades y Accesos.