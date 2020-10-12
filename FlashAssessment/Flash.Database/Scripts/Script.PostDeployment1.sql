/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


-- Seed data
insert Team values ('Alpha'), ('Bravo');
insert [User] values ('Danie vd Merwe', 'danie@test.com', 1), ('Greg Thompson', 'greg@test.com', 1), ('Ivor C', 'ivor@test.com', 2), ('Chantelle R', 'chants@test.com', 2);
insert WorkItemStatus values ('To-do'), ('In Progress'), ('Done');
insert WorkItem values ('Sample Item', 2, 1, null);