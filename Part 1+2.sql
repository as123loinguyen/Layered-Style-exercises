-- T?o database
CREATE DATABASE FilmReviewDB;
GO

-- S? d?ng database v?a t?o
USE FilmReviewDB;
GO

-- T?o b?ng Users
CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY,
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    created_at DATETIME DEFAULT GETDATE()
);
GO

-- T?o b?ng MoviesSeries
CREATE TABLE MoviesSeries (
    movie_series_id INT PRIMARY KEY IDENTITY,
    title VARCHAR(100) NOT NULL,
    genre VARCHAR(50),
    release_date DATE,
    description TEXT
);
GO

-- T?o b?ng Reviews
CREATE TABLE Reviews (
    review_id INT PRIMARY KEY IDENTITY,
    user_id INT NOT NULL,
    movie_series_id INT NOT NULL,
    review_text TEXT,
    review_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (movie_series_id) REFERENCES MoviesSeries(movie_series_id) ON DELETE CASCADE
);
GO

-- T?o b?ng Ratings
CREATE TABLE Ratings (
    rating_id INT PRIMARY KEY IDENTITY,
    user_id INT NOT NULL,
    movie_series_id INT NOT NULL,
    rating DECIMAL(3,2) CHECK (rating >= 0 AND rating <= 10),
    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (movie_series_id) REFERENCES MoviesSeries(movie_series_id) ON DELETE CASCADE
);
GO

-- T?o b?ng Tags
CREATE TABLE Tags (
    tag_id INT PRIMARY KEY IDENTITY,
    tag_name VARCHAR(50) NOT NULL UNIQUE
);
GO

-- T?o b?ng MovieSeriesTags (Join Table ?? h? tr? m?i quan h? nhi?u-nhi?u)
CREATE TABLE MovieSeriesTags (
    movie_series_id INT NOT NULL,
    tag_id INT NOT NULL,
    PRIMARY KEY (movie_series_id, tag_id),
    FOREIGN KEY (movie_series_id) REFERENCES MoviesSeries(movie_series_id) ON DELETE CASCADE,
    FOREIGN KEY (tag_id) REFERENCES Tags(tag_id) ON DELETE CASCADE
);
GO

DROP PROCEDURE IF EXISTS GetMovieReviews;
GO

CREATE PROCEDURE GetMovieReviews
    @movie_series_id INT
AS
BEGIN
    SELECT r.review_id, r.user_id, u.username, r.review_text, r.review_date
    FROM Reviews r
    JOIN Users u ON r.user_id = u.user_id
    WHERE r.movie_series_id = @movie_series_id
    ORDER BY r.review_date DESC;
END;

CREATE PROCEDURE AddReview
    @user_id INT,
    @movie_series_id INT,
    @review_text TEXT
AS
BEGIN
    INSERT INTO Reviews (user_id, movie_series_id, review_text, review_date)
    VALUES (@user_id, @movie_series_id, @review_text, GETDATE());
END;

CREATE PROCEDURE GetTopRatedMovies
    @top_count INT
AS
BEGIN
    SELECT ms.movie_series_id, ms.title, AVG(r.rating) AS avg_rating
    FROM MoviesSeries ms
    JOIN Ratings r ON ms.movie_series_id = r.movie_series_id
    GROUP BY ms.movie_series_id, ms.title
    ORDER BY avg_rating DESC
    OFFSET 0 ROWS FETCH NEXT @top_count ROWS ONLY;
END;

CREATE PROCEDURE GetMoviesByTag
    @tag_name VARCHAR(50)
AS
BEGIN
    SELECT ms.movie_series_id, ms.title, ms.genre, ms.release_date
    FROM MoviesSeries ms
    JOIN MovieSeriesTags mst ON ms.movie_series_id = mst.movie_series_id
    JOIN Tags t ON mst.tag_id = t.tag_id
    WHERE t.tag_name = @tag_name;
END;

-- Thêm ng??i dùng (Users)
INSERT INTO Users (username, email) 
VALUES 
('user1', 'user1_new@example.com'),
('user2', 'user245@example.com'),
('user3', 'user3453@example.com');

-- Thêm phim & series (MoviesSeries)
INSERT INTO MoviesSeries (title, genre, release_date, description) 
VALUES 
('Inception', 'Sci-Fi', '2010-07-16', 'A mind-bending thriller about dreams within dreams.'),
('The Dark Knight', 'Action', '2008-07-18', 'Batman faces off against the Joker.'),
('Interstellar', 'Sci-Fi', '2014-11-07', 'A journey beyond the stars to save humanity.');

SELECT * FROM MoviesSeries;

-- Thêm ?ánh giá (Reviews)
INSERT INTO Reviews (user_id, movie_series_id, review_text) 
VALUES 
(14, 16, 'Absolutely amazing! A masterpiece.'),
(15, 17, 'Great concept, but a bit confusing.'),
(16, 18, 'Heath Ledger was incredible as Joker.'),
(20, 19, 'The visuals and music are breathtaking.');
SELECT * FROM Users;

-- Thêm ?ánh giá s? (Ratings)
INSERT INTO Ratings (user_id, movie_series_id, rating) 
VALUES 
(14, 16, 9.5),
(15, 17, 8.0),
(16, 18, 9.8),
(20, 18, 9.2);



-- Thêm th? lo?i/tag (Tags)
INSERT INTO Tags (tag_name) 
VALUES 
('Sci-Fi'),
('Action'),
('Thriller');
SELECT * FROM Tags;

-- Gán tag cho phim (MovieSeriesTags)
INSERT INTO MovieSeriesTags (movie_series_id, tag_id) 
VALUES 
(16, 18), -- Inception - Sci-Fi
(17, 19), -- Inception - Thriller
(18, 20); -- The Dark Knight - Action






-- Test fetching reviews for a specific movie
EXEC GetMovieReviews @movie_series_id = 16;
-- Test adding a review
EXEC AddReview @user_id = 1, @movie_series_id = 1, @review_text =
'Amazing movie!';
-- Test retrieving top-rated movies
EXEC GetTopRatedMovies @top_count = 5;
-- Test filtering movies by tag
EXEC GetMoviesByTag @tag_name = 'Action';










