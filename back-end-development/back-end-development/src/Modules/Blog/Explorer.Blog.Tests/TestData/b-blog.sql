INSERT INTO blog."Blogs"(
    "Id", "Name", "Description", "DateCreated", "Images", "AuthorId", "Status", "Rating", "Comments", "Ratings")
VALUES (-1, 'Turisticki Blog', 'Sve o turizmu na jednom mestu', '2023-10-17 17:12:31.426+02', 
    array['asdasd', 'asdasdasd'], -11, 1, 1, 
    '[{{
    "UserId": -21,
    "Context": "komentar",
    "CreationTime": "2023-10-17 17:12:31.426+02",
    "LastUpdateTime": "2023-10-17 17:12:31.426+02"
  }},
  {{
    "UserId": -22,
    "Context": "komentar",
    "CreationTime": "2023-10-17 17:12:31.426+02",
    "LastUpdateTime": "2023-10-17 17:12:31.426+02"
  }}]', 
  '[{{
    "UserId": -21,
    "RatingType": 0
  }}]');

INSERT INTO blog."Blogs"(
    "Id", "Name", "Description", "DateCreated", "Images", "AuthorId", "Status", "Rating", "Comments", "Ratings")
VALUES (-2, 'Lovacki Blog', 'Sve o lovu na jednom mestu', '2022-10-17 17:12:31.426+02', 
    array['image2.jpg', 'image3.jpg'], -12, 1, 1, 
  '[{{
    "UserId": -21,
    "Context": "komentar",
    "CreationTime": "2023-11-07 12:00:25.421614+01",
    "LastUpdateTime": "2023-11-07 12:00:25.421614+01"
  }},
  {{
    "UserId": -22,
    "Context": "komentar",
    "CreationTime": "2023-11-07 12:00:25.421614+01",
    "LastUpdateTime": "2023-11-07 12:00:25.421614+01"
  }}]', 
  '[{{
    "UserId": -21,
    "RatingType": 0
  }}]');