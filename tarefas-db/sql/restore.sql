USE master;
GO

IF DB_ID('tarefas-db-sql') IS NULL
BEGIN
	RESTORE DATABASE [tarefas-db-sql]
	FROM DISK = '/var/opt/mssql/backup/tarefas-db-sql.bak'
	WITH REPLACE,
	MOVE 'tarefas-db-sql' TO '/var/opt/mssql/data/tarefas-db-sql.mdf',
	MOVE 'tarefas-db-sql_log' TO '/var/opt/mssql/data/tarefas-db-sql_log.ldf';
END
GO
