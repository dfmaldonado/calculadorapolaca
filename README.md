# Calculator API

Esta es una API para una calculadora que implementa Notación Polaca Inversa. Permite realizar operaciones matemáticas en notación polaca inversa, como suma, resta, multiplicación, división. Además, guarda un historial de operaciones en una base de datos SQLite utilizando Entity Framework Core.

+------------------------+
|      Cliente           |   Swagger
+------------------------+
             |
             v
+------------------------+
|  CalculatorController  |  Recibe solicitudes HTTP y delega
+------------------------+
             |
             v
+------------------------+
|   CalculatorService    |  Lógica de negocio: valida y calcula
+------------------------+
             |
             v
+------------------------+
|  CalculatorDbContext   |  Acceso a la base de datos: guarda y recupera
+------------------------+) ]

PARA EJECUTAR UNA OPERACIÓN:

1 - Colocar los números con la que se desea relizar una operacion: 2, 1, 5 etc
2 - Una vez colocados los numeros a operar seguidamente colocamos el operando deseado: +, /, *, -
3 - Click en execute para obtener el resultado (Debe quedar: "5 6 + [Suma], 3 6 / [División], 3 2 * [Multiplicacion], 2 9 - [Resta]")


PARA OBTENER LISTADO

1 - Click en Execute