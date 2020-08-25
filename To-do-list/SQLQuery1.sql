CREATE TABLE [dbo].[catagory] (
    [c_id]          INT          IDENTITY (1, 1) NOT NULL,
    [Catagory_Name] VARCHAR (50) NULL,
    [user_id]       INT          NULL,
    PRIMARY KEY CLUSTERED ([c_id] ASC)
);
