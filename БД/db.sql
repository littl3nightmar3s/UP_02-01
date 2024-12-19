create table Employees
(
employeeID int primary key identity(1,1),
fio nvarchar(50) not null,
phone nvarchar(12) not null,
[type] nvarchar(10) not null,
[login] nvarchar(50) not null,
[password] nvarchar(50) not null
);

create table Clients
(
clientID int primary key identity(1,1),
fio nvarchar(50) not null,
phone nvarchar(12) not null,
[login] nvarchar(50) not null,
[password] nvarchar(50) not null
);

create table RequestStatus
(
StatusID int primary key identity(1,1),
[status] nvarchar(50) not null
);

create table Tech
(
techID int primary key identity(1,1),
[type] nvarchar(50) not null,
model nvarchar(50) not null
);

create table Requests
(
requestID int primary key identity(1,1),
startDate date not null,
techId int not null,
problem nvarchar(200) not null,
statusId int not null,
completionDate date,
repairParts nvarchar(200),
employeeId int,
clientId int not null,

foreign key (techId) references Tech(techID),
foreign key (statusId) references RequestStatus(StatusID),
foreign key (employeeId) references Employees(employeeID),
foreign key (clientId) references Clients(clientID)
);

create table Comments
(
commentID int primary key identity(1,1),
[message] nvarchar(200) not null,
masterId int not null,
requestId int not null,

foreign key (masterId) references Employees(employeeID),
foreign key (requestId) references Requests(requestID)
);

create table login_attmpts
(
id int primary key identity,
id_user int not null,
login_date date not null,
failure bit not null 
)


-- заполнение
insert into Employees
(fio, phone, [type], [login], [password])
values 
('Трубин Никита Юрьевич', '89210563128', 'Менеджер', 'kasoo', 'root'),
('Мурашов Андрей Юрьевич', '89535078985', 'Мастер', 'murashov123', 'qwerty'),
('Степанов Андрей Викторович', '89210673849', 'Мастер', 'test1', 'test1'),
('Семенова Ясмина Марковна', '89994563847', 'Мастер', 'login1', 'pass1'),
('Иванов Марк Максимович', '89994563844', 'Мастер', 'login5', 'pass5'),
('Перина Анастасия Денисовна', '89990563748', 'Оператор', 'perinaAD', '250519'),
('Мажитова Ксения Сергеевна', '89994563847', 'Оператор', 'krutiha1234567', '1234567890');

insert into Clients
(fio, phone, [login], [password])
values
('Баранова Эмилия Марковна', '89994563841', 'login2', 'pass2'),
('Егорова Алиса Платоновна', '89994563842', 'login3', 'pass3'),
('Титов Максим Иванович', '89994563843', 'login4', 'pass4');

insert into RequestStatus 
(status)
values
('Новая заявка'),
('В процессе ремонта'),
('Готова к выдаче');

insert into Tech
([type], model)
values 
('Фен', 'Ладомир ТА112 белый'),
('Тостер', 'Redmond RT-437 черный'),
('Холодильник', 'Indesit DS 316 W белый'),
('Стиральная машина', 'DEXP WM-F610NTMA/WW белый'),
('Мультиварка', 'Redmond RMC-M95 черный'),
('Фен', 'Ладомир ТА113 чёрный'),
('Холодильник', 'Indesit DS 314 W серый');

insert into Requests
(
startDate, techId, problem, statusId, 
completionDate, repairParts, employeeId, clientId
)
values
('2023-06-06', 1, 'Перестал работать', 1, '2023-06-07', NULL, 2, 2),  
('2023-05-05', 2, 'Перестал работать', 1, '2023-05-06', NULL, 3, 2), 
('2022-07-07', 3, 'Не морозит одна из камер холодильника', 2, '2023-01-01', NULL, 2, 1),  
('2023-08-02', 4, 'Перестали работать многие режимы стирки', 3, '2023-08-05', NULL, NULL, 3),  
('2023-08-02', 5, 'Перестала включаться', 3, '2023-08-06', NULL, NULL, 3), 
('2023-08-02', 6, 'Перестал работать', 2, '2023-08-03', NULL, 2, 2), 
('2023-07-09', 7, 'Гудит, но не замораживает', 2, '2023-08-03', 'Мотор обдува морозильной камеры холодильника', 2, 1); 

insert into Comments
([message], masterId, requestId)
values
('Интересная поломка', 2, 1),
('Очень странно, будем разбираться!', 3, 2),
('Скорее всего потребуется мотор обдува!', 2, 7),
('Интересная проблема', 2, 1),
('Очень странно, будем разбираться!', 3, 6);
