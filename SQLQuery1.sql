use hospital;
--DROP TABLE MedAccount;
--CREATE TABLE MedAccount (
--id INT identity(1,1) PRIMARY KEY not null,
--fullName_med VARCHAR(500) ,
--spec VARCHAR(500),
--bio VARCHAR(3000),
--);
insert into MedAccount(fullName_med, spec, bio) values ('Капылов Сергей Александрович','Стоматолог','Странный чел');
select * from MedAccount;


