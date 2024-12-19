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


-- ����������
insert into Employees
(fio, phone, [type], [login], [password])
values 
('������ ������ �������', '89210563128', '��������', 'kasoo', 'root'),
('������� ������ �������', '89535078985', '������', 'murashov123', 'qwerty'),
('�������� ������ ����������', '89210673849', '������', 'test1', 'test1'),
('�������� ������ ��������', '89994563847', '������', 'login1', 'pass1'),
('������ ���� ����������', '89994563844', '������', 'login5', 'pass5'),
('������ ��������� ���������', '89990563748', '��������', 'perinaAD', '250519'),
('�������� ������ ���������', '89994563847', '��������', 'krutiha1234567', '1234567890');

insert into Clients
(fio, phone, [login], [password])
values
('�������� ������ ��������', '89994563841', 'login2', 'pass2'),
('������� ����� ����������', '89994563842', 'login3', 'pass3'),
('����� ������ ��������', '89994563843', 'login4', 'pass4');

insert into RequestStatus 
(status)
values
('����� ������'),
('� �������� �������'),
('������ � ������');

insert into Tech
([type], model)
values 
('���', '������� ��112 �����'),
('������', 'Redmond RT-437 ������'),
('�����������', 'Indesit DS 316 W �����'),
('���������� ������', 'DEXP WM-F610NTMA/WW �����'),
('�����������', 'Redmond RMC-M95 ������'),
('���', '������� ��113 ������'),
('�����������', 'Indesit DS 314 W �����');

insert into Requests
(
startDate, techId, problem, statusId, 
completionDate, repairParts, employeeId, clientId
)
values
('2023-06-06', 1, '�������� ��������', 1, '2023-06-07', NULL, 2, 2),  
('2023-05-05', 2, '�������� ��������', 1, '2023-05-06', NULL, 3, 2), 
('2022-07-07', 3, '�� ������� ���� �� ����� ������������', 2, '2023-01-01', NULL, 2, 1),  
('2023-08-02', 4, '��������� �������� ������ ������ ������', 3, '2023-08-05', NULL, NULL, 3),  
('2023-08-02', 5, '��������� ����������', 3, '2023-08-06', NULL, NULL, 3), 
('2023-08-02', 6, '�������� ��������', 2, '2023-08-03', NULL, 2, 2), 
('2023-07-09', 7, '�����, �� �� ������������', 2, '2023-08-03', '����� ������ ����������� ������ ������������', 2, 1); 

insert into Comments
([message], masterId, requestId)
values
('���������� �������', 2, 1),
('����� �������, ����� �����������!', 3, 2),
('������ ����� ����������� ����� ������!', 2, 7),
('���������� ��������', 2, 1),
('����� �������, ����� �����������!', 3, 6);
