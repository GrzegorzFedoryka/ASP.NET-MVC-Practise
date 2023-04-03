start docker compose: docker-compose up -d

using db in docker terminal:
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P SqlServer123! # this command redirect to database server context

use CarWorkshopDb # this command used in db server context changes context to specified database, now it's available to write queries
			# ex. Select * from CarWorkshops; 
			# go; -- it runs all queries written above