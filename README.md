# Masivian Rulette API
    * Endpoint de creación de nuevas ruletas que devuelva el id de la nueva ruleta creada
    * Endpoint de apertura de ruleta (el input es un id de ruleta) que permita las
      posteriores peticiones de apuestas, este debe devolver simplemente un estado que
      confirme que la operación fue exitosa o denegada
    * Endpoint de apuesta a un número (los números válidos para apostar son del 0 al 36)
      o color (negro o rojo) de la ruleta una cantidad determinada de dinero (máximo
      10.000 dólares) a una ruleta abierta.
      (nota: este enpoint recibe además de los parámetros de la apuesta, un id de usuario
      en los HEADERS asumiendo que el servicio que haga la petición ya realizo una
      autenticación y validación de que el cliente tiene el crédito necesario para realizar la
      apuesta)
    * Endpoint de cierre apuestas dado un id de ruleta, este endpoint debe devolver el
     resultado de las apuestas hechas desde su apertura hasta el cierre.
    * Endpoint de listado de ruletas creadas con sus estados (abierta o cerrada)
## Install 
    1. $ cd TestMasivian
    2. $ docker-compose -f docker-compose.yml up
    3. Test from postman
    4. Load postman_collection.json and enjoy
    
##URL
    1. POST http://localhost:5000/api/roulette  create roulette
    2. GET http://localhost:5000/api/roulette   List Roulettes
    3. PUT http://localhost:5000/api/roulette/{{roulette_id}}/open open roulette
    4. POST http://localhost:5000/api/roulette/{{roulette_id}}/bet bet
    5. PUT http://localhost:5000/api/roulette/{{roulette_id}}/close close rulette