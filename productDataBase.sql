use AdoDotNetTask
create table tblproduct(
productId int identity primary key,
productName varchar(100),
rate float,
tax float,
stockQuantity int
)
select * from tblproduct