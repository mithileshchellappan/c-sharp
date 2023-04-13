USE [Assessment]


CREATE TABLE Movies
(
    MovieID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Title VARCHAR(255),
    ReleaseYear INT,
    Genre VARCHAR(50),
    Director VARCHAR(100)
);

SET IDENTITY_INSERT Movies ON

INSERT INTO Movies
    (MovieID, Title, ReleaseYear, Genre, Director)
VALUES
    (1, 'The Shawshank Redemption', 1994, 'Drama', 'Frank Darabont'),
    (2, 'The Godfather', 1972, 'Crime', 'Francis Ford Coppola'),
    (3, 'The Dark Knight', 2008, 'Action', 'Christopher Nolan'),
    (4, 'Pulp Fiction', 1994, 'Crime', 'Quentin Tarantino'),
    (5, 'The Lord of the Rings: The Fellowship of the Ring', 2001, 'Adventure', 'Peter Jackson'),
    (6, 'Forrest Gump', 1994, 'Drama', 'Robert Zemeckis'),
    (7, 'Inception', 2010, 'Action', 'Christopher Nolan'),
    (8, 'The Matrix', 1999, 'Action', 'The Wachowskis'),
    (9, 'Goodfellas', 1990, 'Crime', 'Martin Scorsese'),
    (10, 'The Silence of the Lambs', 1991, 'Thriller', 'Jonathan Demme');


SELECT *
FROM MOVIES;

CREATE PROCEDURE FETCH_MOVIES
AS
SELECT *
FROM Movies;

CREATE PROCEDURE ADD_MOVIE
    @Title VARCHAR(30),
    @ReleaseYear INT,
    @Genre VARCHAR(30),
    @Director VARCHAR(30)
AS
INSERT INTO MOVIES
VALUES
    (@Title, @ReleaseYear, @Genre, @Director);

CREATE PROCEDURE EDIT_MOVIE
    @Title VARCHAR(30),
    @ReleaseYear INT,
    @Genre VARCHAR(30),
    @Director VARCHAR(30),
    @MovieID INT
AS
UPDATE Movies SET Title=@Title, ReleaseYear=@ReleaseYear,
Genre=@Genre, Director=@Director
WHERE MovieID=@MovieID;

CREATE PROCEDURE GET_MOVIE
    @MovieID INT
AS
SELECT *
FROM Movies
WHERE MovieID=@MovieID

CREATE PROCEDURE DELETE_MOVIE
	@MovieID INT
AS
DELETE FROM Movies WHERE MovieID=@MovieID