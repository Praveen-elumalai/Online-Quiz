create database demoproject

 use demoproject

create table admin_details( AdminId int,Name varchar(100),Email varchar(100),UserName varchar(100),Password varchar(100))
 
Insert INTO admin_details
 VALUES (101, 'John', 'John101@gmail.com' , 'John101', '12345' );
 
 select * from admin_details	
 
 create proc admin_data
 (@email varchar(100),@password varchar(100))
 as begin
 select * from admin_details where Email = @email and Password = @password
 end
 
--subject table--
 
create table subject_info( 
subject_id int primary key identity,
subject_name varchar(100),
 Is_deleted BIT DEFAULT 0
) 

select * from subject_info
 
 truncate table subject_info
 
 
 create proc get_subject
    @subject_name varchar(100)
as begin 
insert into subject_info (subject_name)
    values (@subject_name);
    select scope_identity() as SubjectId;
end;

create proc sub_webgrid
as begin 
select * from subject_info
end
 
 --get subjects as dropdown
 
 create proc GetSubjects
as  begin
  select subject_id, subject_name from subject_info;
end
 
 --insert questions
 
 
  create table insert_questions
 (Question_id int primary key identity,
  subject_id int ,
  Question_Text varchar(500),
   created_date DATETIME DEFAULT GETDATE())
-- option table
 
 create table options_table (
    option_id int PRIMARY KEY IDENTITY,
    question_id int,
    Options varchar(100),
    option_text varchar(500),
    is_correct BIT,  
)

 

 create proc questionwithoptions
    @SubjectId int,
    @QuestionText varchar(500),
    @Option1Label varchar(100),
    @Option1Text varchar(500),
    @IsCorrect1 bit,
    @Option2Label varchar(100),
    @Option2Text varchar(500),
    @IsCorrect2 bit,
    @Option3Label varchar(100),
    @Option3Text varchar(500),
    @IsCorrect3 bit,
    @Option4Label varchar(100),
    @Option4Text varchar(500),
    @IsCorrect4 bit
as begin
    declare @QuestionId int;
    insert into insert_questions (subject_id, Question_Text)
    values (@SubjectId, @QuestionText);
    set @QuestionId = SCOPE_IDENTITY();
    
    insert into options_table (question_id, Options, option_text, is_correct)
    VALUES
        (@QuestionId, @Option1Label, @Option1Text, @IsCorrect1),
        (@QuestionId, @Option2Label, @Option2Text, @IsCorrect2),
        (@QuestionId, @Option3Label, @Option3Text, @IsCorrect3),
        (@QuestionId, @Option4Label, @Option4Text, @IsCorrect4);

END;


select * from insert_questions

select * from options_table

 truncate table insert_questions
 
 create proc subjectwithquestions
    (@SubjectId INT = NULL) 
as begin
   
    if @SubjectId IS NULL
  begin
select 
       question_id, 
            subject_id, 
            Question_Text
        from insert_questions;
    end 
    else
    begin
        select 
            question_id, 
            subject_id, 
            Question_Text
        from insert_questions
        where subject_id = @SubjectId;
    end
end
 
 
 create proc delete_question
    @QuestionId int
AS
BEGIN
    DELETE FROM insert_questions
    WHERE question_id = @QuestionId;
END


 create Table Quizz
 (QuizId int IDENTITY(1,1),
   QuizName varchar(100),
   Duration varchar (100) ,
   Questions_Count varchar(100))

select * from Quizz

create proc InsertQuizz
    @QuizName varchar(100),
    @Duration varchar(100),
    @Questions_Count varchar (100)
as begin
    INSERT INTO Quizz (QuizName, Duration, Questions_Count)
    VALUES (@QuizName, @Duration, @Questions_Count);
    
end;

 
 
  
create proc View_quizz
as begin
select * from Quizz
end










































--Quiz Table

--create table QuizTable
--(  QuizId int IDENTITY(1,1) primary key,  
--    QuizName varchar(100) NOT NULL,        
--    SubjectId int,                   
--    CreatedDate DATETIME DEFAULT GEtDATE(),
--     QuestionCount int DEFAULT 0);

----Quizquestions

--create table QuizQuestions
--(
--    QuizQuestionId int identity(1,1) primary key ,  
--    QuizId int,                                   
--    QuestionId int,                          
--    foreign key (QuizId) references QuizTable(QuizId),  
--);

----Save The Quiz

--create proc SaveQuiz
--    @QuizName varchar(100),
--    @SubjectId int ,
--    @Question_id int
--    as begin
--    insert  into QuizTable (QuizName, SubjectId,QuestionCount)
--    values (@QuizName, @SubjectId,0)

--  declare @QuizId int;
--    set @QuizId = SCOPE_IDENTITY();

--    insert into QuizQuestions (QuizId,QuestionId)
--    values (@QuizId,  @Question_id)
   
--      update QuizTable
--    set QuestionCount = (select count(*) from QuizQuestions where QuizId = @QuizId)
--    where QuizId = @QuizId;
   
--   end


--select * from QuizTable
--select * from QuizQuestions
 
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 






