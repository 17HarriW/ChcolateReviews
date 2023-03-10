-- Create the chocolate bar table
CREATE TABLE ChocolateBars
(
	[ChocolateBarID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NCHAR(128) NOT NULL, 
    [Price] SMALLMONEY NOT NULL
)

-- Create the review table
CREATE TABLE Reviews
(
	[ReviewID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ChocolateBarID] INT NOT NULL, 
    [UserID] INT NOT NULL, 
    [Score] INT NOT NULL DEFAULT 0, 
    [Comment] TEXT NOT NULL DEFAULT 'No text added'
)

-- Create the user table
CREATE TABLE Users
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] NCHAR(128) NOT NULL DEFAULT '', 
    [LastName] NCHAR(128) NOT NULL DEFAULT ''
)

