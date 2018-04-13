/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2016                    */
/* Created on:     4/12/2018 9:21:59 PM                         */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Account') and o.name = 'FK_ACCOUNT_REFERENCE_PARTY')
alter table Account
   drop constraint FK_ACCOUNT_REFERENCE_PARTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Admin') and o.name = 'FK_ADMIN_REFERENCE_PARTY')
alter table Admin
   drop constraint FK_ADMIN_REFERENCE_PARTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Class') and o.name = 'FK_CLASS_REFERENCE_GRADE')
alter table Class
   drop constraint FK_CLASS_REFERENCE_GRADE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Message') and o.name = 'FK_MESSAGE_REFERENCE_PARTY')
alter table Message
   drop constraint FK_MESSAGE_REFERENCE_PARTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MessageRecipient') and o.name = 'FK_MESSAGER_REFERENCE_PARTY1')
alter table MessageRecipient
   drop constraint FK_MESSAGER_REFERENCE_PARTY1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MessageRecipient') and o.name = 'FK_MESSAGER_REFERENCE_PARTY2')
alter table MessageRecipient
   drop constraint FK_MESSAGER_REFERENCE_PARTY2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MessageRecipient') and o.name = 'FK_MESSAGER_REFERENCE_PARTY3')
alter table MessageRecipient
   drop constraint FK_MESSAGER_REFERENCE_PARTY3
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MessageRecipient') and o.name = 'FK_MESSAGER_REFERENCE_MESSAGE')
alter table MessageRecipient
   drop constraint FK_MESSAGER_REFERENCE_MESSAGE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ParentStudent') and o.name = 'FK_PARENTST_REFERENCE_STUDENT')
alter table ParentStudent
   drop constraint FK_PARENTST_REFERENCE_STUDENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ParentStudent') and o.name = 'FK_PARENTST_REFERENCE_PARENT')
alter table ParentStudent
   drop constraint FK_PARENTST_REFERENCE_PARENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Party') and o.name = 'FK_PARTY_REFERENCE_PARTYTYP')
alter table Party
   drop constraint FK_PARTY_REFERENCE_PARTYTYP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Phone') and o.name = 'FK_PHONE_REFERENCE_PHONECAR')
alter table Phone
   drop constraint FK_PHONE_REFERENCE_PHONECAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Phone') and o.name = 'FK_PHONE_REFERENCE_PARTY')
alter table Phone
   drop constraint FK_PHONE_REFERENCE_PARTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Student') and o.name = 'FK_STUDENT_REFERENCE_PARTY')
alter table Student
   drop constraint FK_STUDENT_REFERENCE_PARTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StudentClass') and o.name = 'FK_STUDENTC_REFERENCE_CLASS')
alter table StudentClass
   drop constraint FK_STUDENTC_REFERENCE_CLASS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StudentClass') and o.name = 'FK_STUDENTC_REFERENCE_STUDENT')
alter table StudentClass
   drop constraint FK_STUDENTC_REFERENCE_STUDENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Teacher') and o.name = 'FK_TEACHER_REFERENCE_PARTY')
alter table Teacher
   drop constraint FK_TEACHER_REFERENCE_PARTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TeacherClass') and o.name = 'FK_TEACHERC_REFERENCE_CLASS')
alter table TeacherClass
   drop constraint FK_TEACHERC_REFERENCE_CLASS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TeacherClass') and o.name = 'FK_TEACHERC_REFERENCE_TEACHER')
alter table TeacherClass
   drop constraint FK_TEACHERC_REFERENCE_TEACHER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Account')
            and   name  = 'AccountIX1'
            and   indid > 0
            and   indid < 255)
   drop index Account.AccountIX1
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Account')
            and   name  = 'AccountIX2'
            and   indid > 0
            and   indid < 255)
   drop index Account.AccountIX2
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Account')
            and   type = 'U')
   drop table Account
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Admin')
            and   type = 'U')
   drop table Admin
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Class')
            and   name  = 'ClassIX2'
            and   indid > 0
            and   indid < 255)
   drop index Class.ClassIX2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Class')
            and   name  = 'ClassIX1'
            and   indid > 0
            and   indid < 255)
   drop index Class.ClassIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Class')
            and   type = 'U')
   drop table Class
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Grade')
            and   name  = 'GradeIX1'
            and   indid > 0
            and   indid < 255)
   drop index Grade.GradeIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Grade')
            and   type = 'U')
   drop table Grade
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Message')
            and   name  = 'MessageIX2'
            and   indid > 0
            and   indid < 255)
   drop index Message.MessageIX2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Message')
            and   name  = 'MessageIX1'
            and   indid > 0
            and   indid < 255)
   drop index Message.MessageIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Message')
            and   type = 'U')
   drop table Message
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MessageRecipient')
            and   name  = 'MessageRecipientIX4'
            and   indid > 0
            and   indid < 255)
   drop index MessageRecipient.MessageRecipientIX4
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MessageRecipient')
            and   name  = 'MessageRecipientIX3'
            and   indid > 0
            and   indid < 255)
   drop index MessageRecipient.MessageRecipientIX3
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MessageRecipient')
            and   name  = 'MessageRecipientIX2'
            and   indid > 0
            and   indid < 255)
   drop index MessageRecipient.MessageRecipientIX2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MessageRecipient')
            and   name  = 'MessageRecipientIX1'
            and   indid > 0
            and   indid < 255)
   drop index MessageRecipient.MessageRecipientIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MessageRecipient')
            and   type = 'U')
   drop table MessageRecipient
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Parent')
            and   type = 'U')
   drop table Parent
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ParentStudent')
            and   name  = 'ParentStudentIX2'
            and   indid > 0
            and   indid < 255)
   drop index ParentStudent.ParentStudentIX2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ParentStudent')
            and   name  = 'ParentStudentIX1'
            and   indid > 0
            and   indid < 255)
   drop index ParentStudent.ParentStudentIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ParentStudent')
            and   type = 'U')
   drop table ParentStudent
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Party')
            and   name  = 'PartyIX3'
            and   indid > 0
            and   indid < 255)
   drop index Party.PartyIX3
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Party')
            and   name  = 'PartyIX2'
            and   indid > 0
            and   indid < 255)
   drop index Party.PartyIX2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Party')
            and   name  = 'PartyIX1'
            and   indid > 0
            and   indid < 255)
   drop index Party.PartyIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Party')
            and   type = 'U')
   drop table Party
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PartyType')
            and   name  = 'PartyTypeIX1'
            and   indid > 0
            and   indid < 255)
   drop index PartyType.PartyTypeIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PartyType')
            and   type = 'U')
   drop table PartyType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Phone')
            and   name  = 'PhoneIX1'
            and   indid > 0
            and   indid < 255)
   drop index Phone.PhoneIX1
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Phone')
            and   name  = 'PhoneIX2'
            and   indid > 0
            and   indid < 255)
   drop index Phone.PhoneIX2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Phone')
            and   name  = 'PhoneIX3'
            and   indid > 0
            and   indid < 255)
   drop index Phone.PhoneIX3
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Phone')
            and   type = 'U')
   drop table Phone
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PhoneCareer')
            and   name  = 'PhoneCareerIX1'
            and   indid > 0
            and   indid < 255)
   drop index PhoneCareer.PhoneCareerIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PhoneCareer')
            and   type = 'U')
   drop table PhoneCareer
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Student')
            and   name  = 'StudentIX1'
            and   indid > 0
            and   indid < 255)
   drop index Student.StudentIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Student')
            and   type = 'U')
   drop table Student
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StudentClass')
            and   name  = 'StudentClassIX2'
            and   indid > 0
            and   indid < 255)
   drop index StudentClass.StudentClassIX2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StudentClass')
            and   name  = 'StudentClassIX1'
            and   indid > 0
            and   indid < 255)
   drop index StudentClass.StudentClassIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StudentClass')
            and   type = 'U')
   drop table StudentClass
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Teacher')
            and   name  = 'TeacherIX1'
            and   indid > 0
            and   indid < 255)
   drop index Teacher.TeacherIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Teacher')
            and   type = 'U')
   drop table Teacher
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TeacherClass')
            and   name  = 'TeacherClassIX2'
            and   indid > 0
            and   indid < 255)
   drop index TeacherClass.TeacherClassIX2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TeacherClass')
            and   name  = 'TeacherClassIX1'
            and   indid > 0
            and   indid < 255)
   drop index TeacherClass.TeacherClassIX1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TeacherClass')
            and   type = 'U')
   drop table TeacherClass
go

/*==============================================================*/
/* Table: Account                                               */
/*==============================================================*/
create table Account (
   AccountID            integer              identity,
   PartyID              integer              not null,
   UserName             varchar(64)          not null,
   Password             binary(64)           not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_ACCOUNT primary key nonclustered (AccountID)
)
go

/*==============================================================*/
/* Index: AccountIX2                                            */
/*==============================================================*/




create unique nonclustered index AccountIX2 on Account (PartyID ASC)
go

/*==============================================================*/
/* Index: AccountIX1                                            */
/*==============================================================*/




create unique clustered index AccountIX1 on Account (UserName ASC)
go

/*==============================================================*/
/* Table: Admin                                                 */
/*==============================================================*/
create table Admin (
   PartyID              integer              not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_ADMIN primary key (PartyID)
)
go

/*==============================================================*/
/* Table: Class                                                 */
/*==============================================================*/
create table Class (
   ClassID              integer              identity,
   GradeID              integer              not null,
   ClassName            varchar(128)         not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_CLASS primary key (ClassID)
)
go

/*==============================================================*/
/* Index: ClassIX1                                              */
/*==============================================================*/




create unique nonclustered index ClassIX1 on Class (ClassName ASC)
go

/*==============================================================*/
/* Index: ClassIX2                                              */
/*==============================================================*/




create nonclustered index ClassIX2 on Class (GradeID ASC)
go

/*==============================================================*/
/* Table: Grade                                                 */
/*==============================================================*/
create table Grade (
   GradeID              integer              identity,
   GradeName            varchar(128)         not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_GRADE primary key (GradeID)
)
go

/*==============================================================*/
/* Index: GradeIX1                                              */
/*==============================================================*/




create unique nonclustered index GradeIX1 on Grade (GradeName ASC)
go

/*==============================================================*/
/* Table: Message                                               */
/*==============================================================*/
create table Message (
   MessageID            integer              identity,
   SenderPartyID        integer              not null,
   MessageGroupID       integer              not null,
   MessageText          varchar(7999)        not null,
   SentToClass          varchar(1)           not null default 'Y',
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_MESSAGE primary key (MessageID)
)
go

/*==============================================================*/
/* Index: MessageIX1                                            */
/*==============================================================*/




create nonclustered index MessageIX1 on Message (SenderPartyID ASC)
go

/*==============================================================*/
/* Index: MessageIX2                                            */
/*==============================================================*/




create nonclustered index MessageIX2 on Message (MessageGroupID ASC)
go

/*==============================================================*/
/* Table: MessageRecipient                                      */
/*==============================================================*/
create table MessageRecipient (
   MessageRecipientID   integer              identity,
   MessageID            integer              not null,
   ParentPartyID        integer              null,
   StudentPartyID       integer              null,
   TeacherPartyID       integer              null,
   ReadDate             datetime             null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_MESSAGERECIPIENT primary key (MessageRecipientID)
)
go

/*==============================================================*/
/* Index: MessageRecipientIX1                                   */
/*==============================================================*/




create nonclustered index MessageRecipientIX1 on MessageRecipient (ParentPartyID ASC)
go

/*==============================================================*/
/* Index: MessageRecipientIX2                                   */
/*==============================================================*/




create nonclustered index MessageRecipientIX2 on MessageRecipient (StudentPartyID ASC)
go

/*==============================================================*/
/* Index: MessageRecipientIX3                                   */
/*==============================================================*/




create nonclustered index MessageRecipientIX3 on MessageRecipient (TeacherPartyID ASC)
go

/*==============================================================*/
/* Index: MessageRecipientIX4                                   */
/*==============================================================*/




create nonclustered index MessageRecipientIX4 on MessageRecipient (MessageID ASC)
go

/*==============================================================*/
/* Table: Parent                                                */
/*==============================================================*/
create table Parent (
   PartyID              integer              not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_PARENT primary key (PartyID)
)
go

/*==============================================================*/
/* Table: ParentStudent                                         */
/*==============================================================*/
create table ParentStudent (
   ParentStudentID      integer              identity,
   StudentPartyID       integer              not null,
   ParentPartyID        integer              not null,
   StartDate            datetime             not null,
   EndDate              datetime             null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_PARENTSTUDENT primary key (ParentStudentID)
)
go

/*==============================================================*/
/* Index: ParentStudentIX1                                      */
/*==============================================================*/




create unique nonclustered index ParentStudentIX1 on ParentStudent (StudentPartyID ASC,
  ParentPartyID ASC)
go

/*==============================================================*/
/* Index: ParentStudentIX2                                      */
/*==============================================================*/




create nonclustered index ParentStudentIX2 on ParentStudent (ParentPartyID ASC)
go

/*==============================================================*/
/* Table: Party                                                 */
/*==============================================================*/
create table Party (
   PartyID              integer              identity,
   PartyTypeID          integer              not null,
   FirstName            varchar(256)         not null,
   MiddleName           varchar(256)         null,
   LastName             varchar(256)         not null,
   Title                varchar(32)          null,
   EmailAddress         varchar(512)         null,
   IsActive             varchar(1)           not null default 'Y',
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_PARTY primary key (PartyID)
)
go

/*==============================================================*/
/* Index: PartyIX1                                              */
/*==============================================================*/




create nonclustered index PartyIX1 on Party (LastName ASC,
  FirstName ASC)
go

/*==============================================================*/
/* Index: PartyIX2                                              */
/*==============================================================*/




create nonclustered index PartyIX2 on Party (EmailAddress ASC)
go

/*==============================================================*/
/* Index: PartyIX3                                              */
/*==============================================================*/




create nonclustered index PartyIX3 on Party (PartyTypeID ASC)
go

/*==============================================================*/
/* Table: PartyType                                             */
/*==============================================================*/
create table PartyType (
   PartyTypeID          integer              identity,
   PartyType            varchar(64)          not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_PARTYTYPE primary key (PartyTypeID)
)
go

/*==============================================================*/
/* Index: PartyTypeIX1                                          */
/*==============================================================*/




create unique nonclustered index PartyTypeIX1 on PartyType (PartyType ASC)
go

/*==============================================================*/
/* Table: Phone                                                 */
/*==============================================================*/
create table Phone (
   PhoneID              integer              identity,
   PhoneCareerID        integer              not null,
   PartyID              integer              not null,
   PhoneNumber          varchar(64)          not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_PHONE primary key (PhoneID)
)
go

/*==============================================================*/
/* Index: PhoneIX3                                              */
/*==============================================================*/




create nonclustered index PhoneIX3 on Phone (PartyID ASC)
go

/*==============================================================*/
/* Index: PhoneIX2                                              */
/*==============================================================*/




create nonclustered index PhoneIX2 on Phone (PhoneCareerID ASC)
go

/*==============================================================*/
/* Index: PhoneIX1                                              */
/*==============================================================*/




create unique nonclustered index PhoneIX1 on Phone (PhoneNumber ASC)
go

/*==============================================================*/
/* Table: PhoneCareer                                           */
/*==============================================================*/
create table PhoneCareer (
   PhoneCareerID        integer              identity,
   PhoneCareerName      varchar(512)         not null,
   SMSGateway           varchar(512)         not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_PHONECAREER primary key (PhoneCareerID)
)
go

/*==============================================================*/
/* Index: PhoneCareerIX1                                        */
/*==============================================================*/




create unique nonclustered index PhoneCareerIX1 on PhoneCareer (PhoneCareerName ASC)
go

/*==============================================================*/
/* Table: Student                                               */
/*==============================================================*/
create table Student (
   PartyID              integer              not null,
   StudentIdentifier    varchar(64)          not null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_STUDENT primary key (PartyID)
)
go

/*==============================================================*/
/* Index: StudentIX1                                            */
/*==============================================================*/




create unique nonclustered index StudentIX1 on Student (StudentIdentifier ASC)
go

/*==============================================================*/
/* Table: StudentClass                                          */
/*==============================================================*/
create table StudentClass (
   StudentClassID       integer              identity,
   PartyID              integer              not null,
   ClassID              integer              not null,
   StartDate            datetime             not null,
   EndDate              datetime             null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_STUDENTCLASS primary key (StudentClassID)
)
go

/*==============================================================*/
/* Index: StudentClassIX1                                       */
/*==============================================================*/




create unique nonclustered index StudentClassIX1 on StudentClass (PartyID ASC,
  ClassID ASC)
go

/*==============================================================*/
/* Index: StudentClassIX2                                       */
/*==============================================================*/




create nonclustered index StudentClassIX2 on StudentClass (ClassID ASC)
go

/*==============================================================*/
/* Table: Teacher                                               */
/*==============================================================*/
create table Teacher (
   PartyID              integer              not null,
   TeacherIdentifier    varchar(64)          not null,
   AvailHoursStart      varchar(16)          null,
   AvailHoursEnd        varchar(32)          null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_TEACHER primary key (PartyID)
)
go

/*==============================================================*/
/* Index: TeacherIX1                                            */
/*==============================================================*/




create unique nonclustered index TeacherIX1 on Teacher (TeacherIdentifier ASC)
go

/*==============================================================*/
/* Table: TeacherClass                                          */
/*==============================================================*/
create table TeacherClass (
   TeacherClassID       integer              identity,
   ClassID              integer              not null,
   TeacherPartyID       integer              not null,
   StartDate            datetime             not null,
   EndDate              datetime             null,
   CreatedBy            varchar(128)         not null,
   CreatedDate          datetime             not null default getdate(),
   ModifiedBy           varchar(128)         null,
   ModifiedDate         datetime             null default getdate(),
   constraint PK_TEACHERCLASS primary key (TeacherClassID)
)
go

/*==============================================================*/
/* Index: TeacherClassIX1                                       */
/*==============================================================*/




create unique nonclustered index TeacherClassIX1 on TeacherClass (ClassID ASC,
  TeacherPartyID ASC)
go

/*==============================================================*/
/* Index: TeacherClassIX2                                       */
/*==============================================================*/




create nonclustered index TeacherClassIX2 on TeacherClass (TeacherPartyID ASC)
go

alter table Account
   add constraint FK_ACCOUNT_REFERENCE_PARTY foreign key (PartyID)
      references Party (PartyID)
go

alter table Admin
   add constraint FK_ADMIN_REFERENCE_PARTY foreign key (PartyID)
      references Party (PartyID)
go

alter table Class
   add constraint FK_CLASS_REFERENCE_GRADE foreign key (GradeID)
      references Grade (GradeID)
go

alter table Message
   add constraint FK_MESSAGE_REFERENCE_PARTY foreign key (SenderPartyID)
      references Party (PartyID)
go

alter table MessageRecipient
   add constraint FK_MESSAGER_REFERENCE_PARTY1 foreign key (ParentPartyID)
      references Party (PartyID)
go

alter table MessageRecipient
   add constraint FK_MESSAGER_REFERENCE_PARTY2 foreign key (StudentPartyID)
      references Party (PartyID)
go

alter table MessageRecipient
   add constraint FK_MESSAGER_REFERENCE_PARTY3 foreign key (TeacherPartyID)
      references Party (PartyID)
go

alter table MessageRecipient
   add constraint FK_MESSAGER_REFERENCE_MESSAGE foreign key (MessageID)
      references Message (MessageID)
go

alter table ParentStudent
   add constraint FK_PARENTST_REFERENCE_STUDENT foreign key (StudentPartyID)
      references Student (PartyID)
go

alter table ParentStudent
   add constraint FK_PARENTST_REFERENCE_PARENT foreign key (ParentPartyID)
      references Parent (PartyID)
go

alter table Party
   add constraint FK_PARTY_REFERENCE_PARTYTYP foreign key (PartyTypeID)
      references PartyType (PartyTypeID)
go

alter table Phone
   add constraint FK_PHONE_REFERENCE_PHONECAR foreign key (PhoneCareerID)
      references PhoneCareer (PhoneCareerID)
go

alter table Phone
   add constraint FK_PHONE_REFERENCE_PARTY foreign key (PartyID)
      references Party (PartyID)
go

alter table Student
   add constraint FK_STUDENT_REFERENCE_PARTY foreign key (PartyID)
      references Party (PartyID)
go

alter table StudentClass
   add constraint FK_STUDENTC_REFERENCE_CLASS foreign key (ClassID)
      references Class (ClassID)
go

alter table StudentClass
   add constraint FK_STUDENTC_REFERENCE_STUDENT foreign key (PartyID)
      references Student (PartyID)
go

alter table Teacher
   add constraint FK_TEACHER_REFERENCE_PARTY foreign key (PartyID)
      references Party (PartyID)
go

alter table TeacherClass
   add constraint FK_TEACHERC_REFERENCE_CLASS foreign key (ClassID)
      references Class (ClassID)
go

alter table TeacherClass
   add constraint FK_TEACHERC_REFERENCE_TEACHER foreign key (TeacherPartyID)
      references Teacher (PartyID)
go

