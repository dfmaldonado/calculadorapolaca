# Calculator API

Esta es una API para una calculadora que implementa Notaci�n Polaca Inversa. Permite realizar operaciones matem�ticas en notaci�n polaca inversa, como suma, resta, multiplicaci�n, divisi�n. Adem�s, guarda un historial de operaciones en una base de datos SQLite utilizando Entity Framework Core.

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
|   CalculatorService    |  L�gica de negocio: valida y calcula
+------------------------+
             |
             v
+------------------------+
|  CalculatorDbContext   |  Acceso a la base de datos: guarda y recupera
+------------------------+) ]

PARA EJECUTAR UNA OPERACI�N:

1 - Colocar los n�meros con la que se desea relizar una operacion: 2, 1, 5 etc
2 - Una vez colocados los numeros a operar seguidamente colocamos el operando deseado: +, /, *, -
3 - Click en execute para obtener el resultado (Debe quedar: "5 6 + [Suma], 3 6 / [Divisi�n], 3 2 * [Multiplicacion], 2 9 - [Resta]")


PARA OBTENER LISTADO

1 - Click en Execute