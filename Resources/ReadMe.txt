# MySql 
# https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html#connector-net-entityframework-core-scaffold-cli
# https://www.connectionstrings.com/mysql/#:~:text=Driver%3D%7BmySQL%7D%3BServer%3D,the%20default%20port%20for%20MySQL.
dotnet ef dbcontext scaffold "Driver={MySQL ODBC 3.51 Driver};Server=localhost;Port=3306;Database=sakila;User=root;Password=Gold`$gym45;Option=3;" MySql.EntityFrameworkCore --namespace ProofOfConcept.Shared --data-annotations --force

#Pomelo for MySQL
#https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql
dotnet ef dbcontext scaffold "server=localhost;user=root;password=Gold`$gym45;database=sakila" "Pomelo.EntityFrameworkCore.MySql" --namespace ProofOfConcept.Shared --data-annotations

#powershell
$mysql = Connect-MySQL  -User "root" -Password "Gold$gym45" -Database "sakila" -Server "localhost" -Port "3306"

#SqlLite 
dotnet ef dbcontext scaffold "Filename=../Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --namespace Packt.Shared --data-annotations

