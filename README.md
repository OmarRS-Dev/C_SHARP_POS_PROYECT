C# POINT OF SALE (POS) SYSTEM
This is a side project I developed at university.

Even though I want to be a backend developer, I enjoy designing and programming desktop applications.
I built this project during my 2nd and 3rd semesters. It may contain some bad practices, but I’m sharing it here because I learned a lot while developing it.
Feel free to use, modify, and adapt it for any purpose

1. Access Form
First, the user must log in with a valid username and password.
This form also includes two buttons:

"Salir" (Close the application).
"Regenerar base de datos" (Restore the database from a previous backup).

2. Main Menu
Since this is an unfinished project, we only have direct access to some forms from the top menu.

"Catálogos": Contains CRUD forms for customers, suppliers, products, and users.
Each CRUD form follows a similar structure, allowing basic data management.

3. Sales (Ventas)
This is the core functionality of the system.

The process starts by selecting the customer (by entering their code).
If the sale is to the general public, the customer code should be set to 0.
Next, the user enters product codes (barcodes). Multiple products can be added as long as they exist in the database.
If the same product is added more than once, the quantity is updated automatically.
Pressing ESC will finalize the sale, prompting for the amount paid by the customer.
If the payment is sufficient, the system calculates the change and prints a receipt.
If the payment is insufficient but the customer is registered, the system allows a credit sale and prints a credit receipt.
There's also a button to search for products in the inventory.

4. Reports
Generates detailed reports for each CRUD section.
(Currently, only the first report is functional).

5. Settings (Props)
Includes various tools such as:

Changing the printer.
Performing manual database backups.
A built-in calculator.
And other general settings.
