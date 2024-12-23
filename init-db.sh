#!/bin/bash

# Espera o SQL Server iniciar completamente
echo "Aguardando o SQL Server iniciar..."
sleep 60

# Executa o script SQL com desativação de validação SSL
echo "Executando script de inicialização..."
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P StrongPassword123 -C -i /docker-entrypoint-initdb.d/initialize.sql



echo "Script executado com sucesso."