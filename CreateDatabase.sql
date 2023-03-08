CREATE TABLE ChocolateBars
(
	[ChocolateBarID] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(128) NOT NULL, 
    [Price] SMALLMONEY NOT NULL
)

CREATE TABLE Reviews
(
	[ReviewID] INT NOT NULL PRIMARY KEY, 
    [ChocolateBarID] INT NOT NULL, 
    [UserID] INT NOT NULL, 
    [Score] INT NOT NULL, 
    [Comment] TEXT NOT NULL
)

CREATE TABLE Users
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [FirstName] NCHAR(128) NOT NULL, 
    [LastName] NCHAR(128) NOT NULL
)

