create table WorkerTypes
(
	TypeId int identity primary key,
	TypeName nvarchar(20) not null
)
go
create table Workers
(
	WorkerId int identity primary key,
	WorkerName nvarchar(30) not null,
	Salary money not null,
	Picture nvarchar(200) null,
	TypeId int not null references WorkerTypes(TypeId)
)
go