GO
Create table TBL_AppoinmentCheck (AppID numeric,CheckboxValue int,UDT1 nvarchar(100),UDT2 nvarchar(100),UDT3 nvarchar(100))
GO

ALTER Proc [dbo].[USP_TBL_Appointment] 
 @action int,@actionby numeric,@AppID numeric  
,@UserID numeric,@FullName nvarchar(100),@EmailID nvarchar(100),@PhoneNo nvarchar(100)  
,@AppDate date,@Message  nvarchar(max)  
,@Class nvarchar(200),@address nvarchar(500),@Photo nvarchar(500),@AppCode nvarchar(100)  
,@FromTime nvarchar(100),@ToTime nvarchar(100),@WhatsappNo nvarchar(100)  
,@State nvarchar(100),@City nvarchar(100),@UDT1 nvarchar(100),@UDT2 nvarchar(100)  
,@UDT3 nvarchar(100),@UDT4 nvarchar(100),@UDT5 nvarchar(100) ,@CurrAppCode nvarchar(20)=NULL, @CheckboxNo int=NULL
As

Begin  
  
if(@action=1)  
Begin  
 insert into TBL_Appointment  
 (UserID,FullName,EmailID,PhoneNo,AppDate,Message,Status,EnterBy,EntryDate,Class,address,Photo,AppCode  
,FromTime,ToTime,WhatsappNo,State,City,UDT1,UDT2,UDT3,UDT4,UDT5)  
  values (@UserID,@FullName,@EmailID,@PhoneNo,@AppDate,@Message,1,@actionby,getdate()  
 ,@Class,@address,@Photo,@AppCode,@FromTime,@ToTime,@WhatsappNo,@State,@City,@UDT1,@UDT2,@UDT3,@UDT4,@UDT5)  
End  
else if(@action=2)  
Begin  
 update TBL_Appointment set FullName=@FullName,EmailID=@EmailID,PhoneNo=@PhoneNo,AppDate=@AppDate,Message=@Message,  
 Class=@Class,address=@address,Photo=@Photo,FromTime=@FromTime,ToTime=@ToTime,WhatsappNo=@WhatsappNo  
 ,State=@State,City=@City  
  where AppID=@AppID  
End  
else if(@action=3)  
Begin  
 update TBL_Appointment set Status=0  where AppID=@AppID  
End  
else if(@action=4)  
Begin  

/* UDT3 ADD INCREMENTS*/	

select @CurrAppCode=AppCode,@AppID=AppID from TBL_Appointment(nolock) where AppCode=@AppCode
select @CheckboxNo=CheckboxValue from TBL_AppoinmentCheck where AppID=@AppID
IF( @CheckboxNo=2 )
BEGIN
	Declare @maxUdt int
	select UDT3 from TBL_Appointment where UDT3 LIKE '%'+ISNULL(@CurrAppCode,'')+'%'
	
	IF EXISTS(select UDT3 from TBL_Appointment where UDT3 LIKE '%'+ISNULL(@CurrAppCode,'')+'%')
	BEGIN
		PRINT 'AVAILABLE'
		select @maxUdt=ISNULL(MAX(
			CASE WHEN  ISNULL(CHARINDEX('-',UDT3),0)>0 
				 THEN  SUBSTRING(UDT3,ISNULL(CHARINDEX('-',UDT3),0)+1,len(UDT3))
				 ELSE 0
				 END ),0) FROM TBL_Appointment where UDT3 LIKE '%'+ISNULL(@CurrAppCode,'')+'%'
		--SELECT @maxUdt AS maxUdt

	END
	ELSE 
	BEGIN
		SET @maxUdt=0
	END
	UPDATE TBL_Appointment 
	SET UDT2=@maxUdt+1
	where AppCode=ISNULL(@CurrAppCode,'')
	
	DECLARE @NewUDT3 varchar(30)
	SET @NewUDT3=ISNULL(@CurrAppCode,'')+'-'+CAST(@maxUdt+1 AS VARCHAR(20)) 
	
END

/*END UDT3 ADD INCREMENTS*/

 --insert into TBL_Appointment values (@UserID,@FullName,@EmailID,@PhoneNo,@AppDate,@Message,0,@actionby,getdate()  
 --,@Class,@address,@Photo,@AppCode,@FromTime,@ToTime,@WhatsappNo,@State,@City,@UDT1,@UDT2,ISNULL(@NewUDT3,''),@UDT4,@UDT5)  
End  
  
End