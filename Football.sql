delete from dbo.userrole where roleid = 3 and userid != '9bfa7dfb-36f3-4112-9bd7-4784cb0f07ba';
delete from dbo.FootballPoolUsers where simpleUserId != 3;
delete from dbo.users where simpleUserId != 3;
delete from dbo.users where id = '25cd4285-a06f-4478-86b3-8302375e7ee7'
delete from dbo.FootballPoolUsers where simpleUserId = 37


insert into dbo.FootballPoolUsers (simpleUserId,userName,userScore,win,loss,signedUpDate) values ('36','alliec613',0.00,0,0,getdate())
insert into dbo.UserRole (userId,roleid) values ('43aa7f7a-275c-43e5-b58b-4ac6448a8daf',3)
insert into dbo.userrole (userid,roleid) values ('b7cffed1-b335-4dca-af9e-53065585cc44',3), ('8084d9d0-751f-47e2-a9b8-b427cf68a5a1',3),('2ee443cf-98e7-40ca-95b8-80e98cf803c1',3);
insert into dbo.FootballPoolUsers (simpleUserId,userName,userScore,win,loss,userId_Id) values ('24','ShaneFalco',0.00,0,0,'2ee443cf-98e7-40ca-95b8-80e98cf803c1'),('26','Jhickey28',0.00,0,0,'8084d9d0-751f-47e2-a9b8-b427cf68a5a1'),('25','higgs1881',0.00,0,0,'b7cffed1-b335-4dca-af9e-53065585cc44');




update dbo.footballpoolusers set signedUpDate = getdate()
update dbo.users set isplayingfootballpool = 0  where simpleuserid = 3; --blahhhhh