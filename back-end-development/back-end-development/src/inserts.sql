-- INSERT SKRIPTA
-- PRIJE OTVARANJA PR-a OBAVEZNO DODATI INSERTE U OVU SKRIPTU!!!


--STAKEHOLDERS SCHEMA

   -- USERS
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (101, 'admin', 'admin', 0, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (102, 'autor1', 'autor1', 1, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (103, 'autor2', 'autor2', 1, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (104, 'autor3', 'autor3', 1, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (105, 'turista1', 'turista1', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (106, 'turista2', 'turista2', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (107, 'turista3', 'turista3', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (108, 'turista4', 'turista4', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (109, 'turista5', 'turista5', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (110, 'turista6', 'turista6', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (111, 'turista7', 'turista7', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (112, 'turista8', 'turista8', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (113, 'turista9', 'turista9', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (114, 'turista10', 'turista10', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (115, 'turista11', 'turista11', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (116, 'turista12', 'turista12', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (117, 'turista13', 'turista13', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (118, 'turista14', 'turista14', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (119, 'turista15', 'turista15', 2, true);
        INSERT INTO stakeholders."Users"(
            "Id", "Username", "Password", "Role", "IsActive")
        VALUES (120, 'turista16', 'turista16', 2, true);

        -- PEOPLE
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (101, 101, 'Admin', 'Admin', 'admin@gmail.com', '', '', '', 45.252755, 19.855550);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (102, 102, 'Lena', 'Lenić', 'autor1@gmail.com', '', '', '', 45.247864, 19.839611);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (103, 103, 'Sara', 'Sarić', 'autor2@gmail.com', '', '', '', 45.236968, 19.826930);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (104, 104, 'Marko', 'Marković', 'autor3@gmail.com', '', '', '', 45.25345110708909, 19.862831282348104);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude" )
        VALUES (105, 105, 'Pera', 'Perić', 'oisisiprojekat@gmail.com', '', '', '', 45.23898527616725, 19.832443488886526);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (106, 106, 'Mika', 'Mikić', 'oisisiprojekat@gmail.com', '', '', '', 45.251232, 19.836311);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (107, 107, 'Steva', 'Stević', 'oisisiprojekat@gmail.com', '', '', '', 45.247864, 19.839611);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (108, 108, 'Mika', 'Mikić', 'oisisiprojekat@gmail.com', '', '', '', 45.236968, 19.826930);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (109, 109, 'Coa', 'Marinković', 'oisisiprojekat@gmail.com', '', '', '', 45.252755, 19.855550);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (110, 110, 'Laza', 'Lazić', 'oisisiprojekat@gmail.com', '', '', '', 45.25345110708909, 19.862831282348104);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (111, 111, 'Bob', 'Johnson', 'bob@gmail.com', '', '', '', 45.247864, 19.839611);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (112, 112, 'Alice', 'Smith', 'alice@gmail.com', '', '', '', 45.252755, 19.855550);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (113, 113, 'Charlie', 'Brown', 'charlie@gmail.com', '', '', '', 45.25345110708909, 19.862831282348104);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (114, 114, 'David', 'Miller', 'david@gmail.com', '', '', '', 45.252755, 19.855550);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (115, 115, 'Eva', 'Wilson', 'eva@gmail.com', '', '', '', 45.236968, 19.826930);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (116, 116, 'Frank', 'Jones', 'frank@gmail.com', '', '', '', 45.25345110708909, 19.862831282348104);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (117, 117, 'Grace', 'Clark', 'grace@gmail.com', '', '', '', 45.247864, 19.839611);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (118, 118, 'Hank', 'Davis', 'hank@gmail.com', '', '', '', 45.236968, 19.826930);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (119, 119, 'Ivy', 'Moore', 'ivy@gmail.com', '', '', '', 45.252755, 19.855550);
        INSERT INTO stakeholders."People"(
            "Id", "UserId", "Name", "Surname", "Email", "Motto", "Biography", "Image", "Latitude", "Longitude")
        VALUES (120, 120, 'Jack', 'Roberts', 'jack@gmail.com', '', '', '', 45.247864, 19.839611);


        

    --APPLICATION RATE
    INSERT INTO stakeholders."ApplicationRate"(
        "Id", "PersonId", "Rate", "Comment", "CreationTime")
        VALUES (101, 105, 3, 'bez', '2023-10-23 08:55:44');
    INSERT INTO stakeholders."ApplicationRate"(
        "Id", "PersonId", "Rate", "Comment", "CreationTime")
        VALUES (102, 106, 1, 'bez kom2', '2023-10-23 08:55:44');

--REQUEST TO JOIN CLUB
    INSERT INTO stakeholders."RequestsToJoinClub"(
        "Id", "TouristId", "TouristClubId", "Status")
    VALUES (101, 105, 101, 0);
    INSERT INTO stakeholders."RequestsToJoinClub"(
        "Id", "TouristId", "TouristClubId", "Status")
    VALUES (102, 106, 101, 0);
    INSERT INTO stakeholders."RequestsToJoinClub"(
        "Id", "TouristId", "TouristClubId", "Status")
    VALUES (103, 107, 102, 0);

--CLUB USERS
    INSERT INTO stakeholders."ClubUsers"(
        "Id", "TouristId", "TouristClubId")
    VALUES (101, 107, 101);

--CLUB REQUESTS
    INSERT INTO stakeholders."ClubRequests"(
        "Id", "TouristId", "TouristClubId", "Status")
    VALUES (101, 105, 101, 0);
    INSERT INTO stakeholders."ClubRequests"(
        "Id", "TouristId", "TouristClubId", "Status")
    VALUES (102, 106, 101, 0);
    INSERT INTO stakeholders."ClubRequests"(
        "Id", "TouristId", "TouristClubId", "Status")
    VALUES (103, 107, 102, 0);

--NOTIFICATIONS
    INSERT INTO stakeholders."Notifications"(
        "Id", "SenderId", "ReceiverId", "Message", "IsRead")
    VALUES (101, 105, 106,'Poruka1', true);
    INSERT INTO stakeholders."Notifications"(
        "Id", "SenderId", "ReceiverId", "Message", "IsRead")
    VALUES (102, 106, 105,'Poruka2', true);

--FOLLOWERS
    INSERT INTO stakeholders."Followers"(
        "Id", "FollowedId", "FollowingId")
    VALUES (101, 107, 106);
    INSERT INTO stakeholders."Followers"(
        "Id", "FollowedId", "FollowingId")
    VALUES (102, 106, 107);


--TOURS SCHEMA

    --TOURS
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
        VALUES (101, 102, 'Planinarska tura', 'Opis planinarske ture', 0, 
                '[
                { "TravelTime": 30, "TravelMethod": 0 },
                { "TravelTime": 60, "TravelMethod": 1 },
                { "TravelTime": 15, "TravelMethod": 2 }
                ]', 0, 0, 'planina,reka,suma', 100, NULL, NULL);
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
        VALUES (102, 103, 'Okeanska tura', 'Opis okeanske ture', 0, 
                '[
                { "TravelTime": 15, "TravelMethod": 0 },
                { "TravelTime": 30, "TravelMethod": 1 },
                { "TravelTime": 10, "TravelMethod": 2 }
                ]', 1, 200, 'okean,ostrvo', 100, '2023-11-09 15:00:25.421614+01', NULL);
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
        VALUES (103, 102, 'Pustinjska tura', 'Opis pustinjske ture', 0, 
                '[
                { "TravelTime": 40, "TravelMethod": 0 },
                { "TravelTime": 70, "TravelMethod": 1 },
                { "TravelTime": 20, "TravelMethod": 2 }
                ]', 1, 20, 'pustinja,pesak', 150, '2023-11-09 15:00:25.421614+01', NULL);
            -- Insert 1
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (104, 102, 'Mountain Expedition', 'Exciting mountain adventure', 2, 
            '[
            { "TravelTime": 50, "TravelMethod": 0 },
            { "TravelTime": 60, "TravelMethod": 1 },
            { "TravelTime": 30, "TravelMethod": 2 }
            ]', 1, 30, 'mountain,climbing', 200, '2023-11-09 16:30:45.123456+01', NULL);

    -- Insert 2
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (105, 103, 'Cultural Tour', 'Explore rich cultural heritage', 1, 
            '[
            { "TravelTime": 20, "TravelMethod": 2 },
            { "TravelTime": 40, "TravelMethod": 1 },
            { "TravelTime": 60, "TravelMethod": 0 }
            ]', 2, 25, 'culture,history', 120, '2023-11-10 10:45:37.987654+01', NULL);

    -- Insert 3
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (106, 102, 'Scuba Diving Adventure', 'Underwater exploration', 0, 
            '[
            { "TravelTime": 10, "TravelMethod": 2 },
            { "TravelTime": 30, "TravelMethod": 1 },
            { "TravelTime": 50, "TravelMethod": 0 }
            ]', 1, 40, 'diving,underwater', 80, '2023-11-11 08:15:10.567890+01', NULL);

    -- Insert 4
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (107, 103, 'City Exploration', 'Discover the urban landscape', 1, 
            '[
            { "TravelTime": 15, "TravelMethod": 2 },
            { "TravelTime": 25, "TravelMethod": 0 },
            { "TravelTime": 45, "TravelMethod": 1 }
            ]', 1, 15, 'city,explore', 60, '2023-11-12 12:30:15.135792+01', NULL);

    -- Insert 5
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (108, 102, 'Wildlife Safari', 'Experience the thrill of wildlife', 2, 
            '[
            { "TravelTime": 60, "TravelMethod": 1 },
            { "TravelTime": 40, "TravelMethod": 2 },
            { "TravelTime": 20, "TravelMethod": 0 }
            ]', 1, 35, 'safari,wildlife', 180, '2023-11-13 14:20:30.987654+01', NULL);

    -- Insert 6
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (109, 103, 'Island Paradise', 'Relax on a beautiful island', 1, 
            '[
            { "TravelTime": 25, "TravelMethod": 0 },
            { "TravelTime": 35, "TravelMethod": 1 },
            { "TravelTime": 55, "TravelMethod": 2 }
            ]', 1, 50, 'island,beach', 100, '2023-11-14 17:45:22.345678+01', NULL);

    -- Insert 7
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (110, 102, 'Historical Journey', 'Explore ancient landmarks', 2, 
            '[
            { "TravelTime": 30, "TravelMethod": 1 },
            { "TravelTime": 50, "TravelMethod": 0 },
            { "TravelTime": 20, "TravelMethod": 2 }
            ]', 1, 28, 'history,ancient', 140, '2023-11-15 09:10:18.876543+01', NULL);

    -- Insert 8
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (111, 103, 'Adventure on the River', 'Thrilling river expedition', 1, 
            '[
            { "TravelTime": 40, "TravelMethod": 2 },
            { "TravelTime": 60, "TravelMethod": 0 },
            { "TravelTime": 30, "TravelMethod": 1 }
            ]', 1, 45, 'river,adventure', 90, '2023-11-16 11:55:26.654321+01', NULL);

    -- Insert 9
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (112, 102, 'Mystical Caves Exploration', 'Discover hidden cave wonders', 2, 
            '[
            { "TravelTime": 20, "TravelMethod": 0 },
            { "TravelTime": 40, "TravelMethod": 1 },
            { "TravelTime": 60, "TravelMethod": 2 }
            ]', 1, 38, 'cave,exploration', 120, '2023-11-17 14:40:12.987654+01', NULL);

    -- Insert 10
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (113, 103, 'Skiing Adventure', 'Thrilling skiing experience', 1, 
            '[
            { "TravelTime": 15, "TravelMethod": 1 },
            { "TravelTime": 25, "TravelMethod": 2 },
            { "TravelTime": 35, "TravelMethod": 0 }
            ]', 1, 55, 'skiing,adventure', 70, '2023-11-18 16:25:08.765432+01', NULL);

    -- Insert 11
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (114, 102, 'Mountain Hike', 'A scenic hike in the mountains', 1,
            '[
            { "TravelTime": 20, "TravelMethod": 0 },
            { "TravelTime": 30, "TravelMethod": 1 },
            { "TravelTime": 40, "TravelMethod": 2 }
            ]', 1, 45, 'hiking,scenery', 50, '2023-11-19 10:15:30.987654+01', NULL);

    -- Insert 12
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (115, 103, 'Cycling Tour', 'Explore the countryside on a bicycle', 2,
            '[
            { "TravelTime": 25, "TravelMethod": 2 },
            { "TravelTime": 35, "TravelMethod": 0 },
            { "TravelTime": 45, "TravelMethod": 1 }
            ]', 1, 30, 'cycling,adventure', 60, '2023-11-20 14:45:12.345678+01', NULL);

    -- Insert 13
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (116, 102, 'Historical Tour', 'Journey through historical landmarks', 0,
            '[
            { "TravelTime": 15, "TravelMethod": 1 },
            { "TravelTime": 25, "TravelMethod": 2 },
            { "TravelTime": 35, "TravelMethod": 0 }
            ]', 1, 40, 'history,tour', 40, '2023-11-21 09:30:45.876543+01', NULL);

    -- Insert 14
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (117, 103, 'Sailing Adventure', 'Sail across the open seas', 1,
            '[
            { "TravelTime": 30, "TravelMethod": 2 },
            { "TravelTime": 40, "TravelMethod": 1 },
            { "TravelTime": 50, "TravelMethod": 0 }
            ]', 1, 70, 'sailing,adventure', 80, '2023-11-22 12:10:15.543210+01', NULL);

    -- Insert 15
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (118, 102, 'Cultural Experience', 'Immerse in local traditions and culture', 2,
            '[
            { "TravelTime": 20, "TravelMethod": 0 },
            { "TravelTime": 30, "TravelMethod": 1 },
            { "TravelTime": 40, "TravelMethod": 2 }
            ]', 1, 55, 'culture,experience', 45, '2023-11-23 15:20:35.678901+01', NULL);

    -- Insert 16
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (119, 103, 'Wildlife Safari', 'Explore the wilderness and wildlife', 1,
            '[
            { "TravelTime": 25, "TravelMethod": 2 },
            { "TravelTime": 35, "TravelMethod": 0 },
            { "TravelTime": 45, "TravelMethod": 1 }
            ]', 1, 60, 'safari,wildlife', 65, '2023-11-24 11:55:25.123456+01', NULL);

    -- Insert 17
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (120, 102, 'Hot Air Balloon Ride', 'A breathtaking view from the sky', 0,
            '[
            { "TravelTime": 15, "TravelMethod": 1 },
            { "TravelTime": 25, "TravelMethod": 2 },
            { "TravelTime": 35, "TravelMethod": 0 }
            ]', 1, 75, 'balloon,adventure', 30, '2023-11-25 07:40:55.432109+01', NULL);

    -- Insert 18
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (121, 103, 'Wine Tasting Tour', 'Savor the finest wines in the region', 2,
            '[
            { "TravelTime": 20, "TravelMethod": 0 },
            { "TravelTime": 30, "TravelMethod": 1 },
            { "TravelTime": 40, "TravelMethod": 2 }
            ]', 1, 50, 'wine,tasting', 35, '2023-11-26 14:15:10.987654+01', NULL);

    -- Insert 19
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (122, 102, 'Fishing Expedition', 'Experience the thrill of fishing', 1,
            '[
            { "TravelTime": 25, "TravelMethod": 2 },
            { "TravelTime": 35, "TravelMethod": 0 },
            { "TravelTime": 45, "TravelMethod": 1 }
            ]', 1, 40, 'fishing,adventure', 55, '2023-11-27 09:25:30.876543+01', NULL);

    -- Insert 20
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (123, 103, 'Surfing Adventure', 'Ride the waves on a thrilling surfing adventure', 2,
            '[
            { "TravelTime": 30, "TravelMethod": 1 },
            { "TravelTime": 40, "TravelMethod": 2 },
            { "TravelTime": 50, "TravelMethod": 0 }
            ]', 1, 65, 'surfing,adventure', 75, '2023-11-28 12:30:45.765432+01', NULL);

    -- Insert 21
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (124, 102, 'City Exploration', 'Discover the vibrant city life', 0,
            '[
            { "TravelTime": 15, "TravelMethod": 2 },
            { "TravelTime": 25, "TravelMethod": 0 },
            { "TravelTime": 35, "TravelMethod": 1 }
            ]', 1, 35, 'city,exploration', 20, '2023-11-29 15:40:10.654321+01', NULL);

    -- Insert 22
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (125, 103, 'Paragliding Adventure', 'Soar through the sky with a paragliding adventure', 1,
            '[
            { "TravelTime": 20, "TravelMethod": 1 },
            { "TravelTime": 30, "TravelMethod": 2 },
            { "TravelTime": 40, "TravelMethod": 0 }
            ]', 1, 80, 'paragliding,adventure', 25, '2023-11-30 09:55:25.789012+01', NULL);

    -- Insert 23
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (126, 102, 'Gastronomic Tour', 'Indulge in a culinary journey', 2,
            '[
            { "TravelTime": 25, "TravelMethod": 0 },
            { "TravelTime": 35, "TravelMethod": 1 },
            { "TravelTime": 45, "TravelMethod": 2 }
            ]', 1, 55, 'gastronomy,tour', 40, '2023-12-01 13:20:35.432109+01', NULL);

    -- Insert 24
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (127, 103, 'Zip Line Adventure', 'Experience the thrill of a high-speed zip line', 1,
            '[
            { "TravelTime": 30, "TravelMethod": 2 },
            { "TravelTime": 40, "TravelMethod": 0 },
            { "TravelTime": 50, "TravelMethod": 1 }
            ]', 1, 60, 'zip,line,adventure', 70, '2023-12-02 08:45:50.567890+01', NULL);

    -- Insert 25
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (128, 102, 'Rock Climbing Expedition', 'Conquer the heights with rock climbing', 0,
            '[
            { "TravelTime": 15, "TravelMethod": 1 },
            { "TravelTime": 25, "TravelMethod": 2 },
            { "TravelTime": 35, "TravelMethod": 0 }
            ]', 1, 70, 'rock,climbing,adventure', 55, '2023-12-03 12:10:15.234567+01', NULL);

    -- Insert 26
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (129, 103, 'Dolphin Watching', 'Sail the seas and watch dolphins in their natural habitat', 1,
            '[
            { "TravelTime": 20, "TravelMethod": 0 },
            { "TravelTime": 30, "TravelMethod": 1 },
            { "TravelTime": 40, "TravelMethod": 2 }
            ]', 1, 45, 'dolphin,watching', 35, '2023-12-04 14:35:30.987654+01', NULL);

    -- Insert 27
    INSERT INTO tours."Tours"(
        "Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
    VALUES (130, 102, 'Photography Expedition', 'Capture stunning moments on a photography expedition', 2,
            '[
            { "TravelTime": 25, "TravelMethod": 2 },
            { "TravelTime": 35, "TravelMethod": 0 },
            { "TravelTime": 45, "TravelMethod": 1 }
            ]', 1, 60, 'photography,expedition', 50, '2023-12-05 10:50:45.876543+01', NULL);


--TOURIST CLUBS
    INSERT INTO tours."TouristClubs" ("Id", "ClubName", "Description", "Image", "OwnerId")
    VALUES (101,'Club 1', 'Description 1', 'Image URL 1', 108);
    INSERT INTO tours."TouristClubs" ("Id", "ClubName", "Description", "Image", "OwnerId")
    VALUES (102,'Club 2', 'Description 2', 'Image URL 2', 109);
    INSERT INTO tours."TouristClubs" ("Id", "ClubName", "Description", "Image", "OwnerId")
    VALUES  (103,'Club 3', 'Description 3', 'Image URL 3', 110);


    --CHECKPOINTS
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
        VALUES (101, 'cp1', 'cp1','cp1.jpg', 45.252755, 19.855550, 101);
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
        VALUES (102, 'cp2', 'cp2','cp2.jpg', 45.247864, 19.839611, 101);
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
        VALUES (103, 'cp3', 'cp3','cp3.jpg', 45.236968, 19.826930, 101);
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
        VALUES (104, 'Petrovaradinska tvrđava', 'Mjesto sa kojeg imate sjajan pogled na rijeku Dunav kao i sam Novi Sad', 'assets/images/tour1.jpg', 45.25345110708909, 19.862831282348104, 102);
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
        VALUES (105, 'Centar', 'Obilazak centra grada gdje se pruza prilika da osjetite pravi duh samog grada', 'assets/images/tour2.jpg', 45.24417022389905, 19.848637999625225, 102);
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
        VALUES (106, 'Dunavski park', 'Park u centru grada', 'assets/images/tour3.jpg', 45.23898527616725, 19.832443488886526, 102);
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
        VALUES (107, 'Avala', 'Sjajan vidikovac', 'assets/images/tour4.jpg', 0, 0, 103);
    -- Insert 8
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (108, 'Trg Slobode', 'Central square in Novi Sad', 'assets/images/tour5.jpg', 45.251232, 19.836311, 105);

    -- Insert 9
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (109, 'Dunavski kej', 'Promenade along the Danube River', 'assets/images/monkey.jpg', 45.259963, 19.828440, 105);

    -- Insert 10
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (110, 'Fruška Gora National Park', 'Nature reserve and national park near Novi Sad', 'assets/images/tour6.jpg', 45.191910, 19.879249, 106);

    -- Insert 11
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (111, 'Petrovaradin Fortress', 'Historical fortress on the right bank of the Danube', 'assets/images/tour6.jpg', 45.253070, 19.872268, 106);

    -- Insert 12
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (112, 'Svetozar Miletic Square', 'Main square in Novi Sad', 'assets/images/tour7.jpg', 45.255836, 19.845573, 107);

    -- Insert 13
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (113, 'Danube Park', 'Park along the Danube River', 'assets/images/tour7.jpg', 45.249376, 19.848135, 107);

    -- Insert 14
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (114, 'The Name of Mary Church', 'Landmark church in Novi Sad', 'assets/images/tour8.jpg', 45.257169, 19.846578, 108);

    -- Insert 15
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (115, 'Dunavska Street', 'Historic street in the city center', 'assets/images/tour8.jpg', 45.254316, 19.845824, 108);

    -- Insert 16
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (116, 'City Hall', 'Government building in Novi Sad', 'assets/images/tour27.jpg', 45.255726, 19.845021, 109);

    -- Insert 17
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (117, 'Zmaj Jovina Street', 'Pedestrian zone with shops and cafes', 'assets/images/tour27.jpg', 45.253635, 19.842817, 109);

    -- Insert 18
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (118, 'Serbian National Theatre', 'Cultural institution in Novi Sad', 'assets/images/tour28.jpg', 45.251894, 19.843656, 110);

    -- Insert 19
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (119, 'Petrovaradinska tvrdjava', 'Mjesto sa kojeg imate sjajan pogled na rijeku Dunav kao i sam Novi Sad', 'assets/images/tour31.jpg', 45.253070, 19.872268, 110);

    -- Insert 20
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (120, 'Centar', 'Obilazak centra grada gdje se pruza prilika da osjetite pravi duh samog grada', 'assets/images/tour29.jpg', 45.255836, 19.845573, 111);

    -- Insert 21
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (121, 'Dunavski park', 'Park u centru grada', 'assets/images/tour29.jpg', 45.249376, 19.848135, 111);

    -- Insert 22
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (122, 'Avala', 'Sjajan vidikovac', 'assets/images/tour30.jpg', 45.208352, 20.624540, 112);

    -- Insert 23
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (123, 'Trg Slobode', 'Central square in Novi Sad', 'assets/images/tour30.jpg', 45.251232, 19.836311, 112);

    -- Insert 24
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (124, 'Dunavski kej', 'Promenade along the Danube River', 'assets/images/tour23.jpg', 45.259963, 19.828440, 113);

    -- Insert 25
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (125, 'Fruška Gora National Park', 'Nature reserve and national park near Novi Sad', 'assets/images/tour10.jpg', 45.191910, 19.879249, 113);

    -- Insert 26
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (126, 'Petrovaradin Fortress', 'Historical fortress on the right bank of the Danube', 'assets/images/tour9.jpg', 45.253070, 19.872268, 114);

    -- Insert 27
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (127, 'Svetozar Miletic Square', 'Main square in Novi Sad', 'assets/images/tour9.jpg', 45.255836, 19.845573, 114);

    -- Insert 28
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (128, 'Danube Park', 'Park along the Danube River', 'assets/images/tour11.jpg', 45.249376, 19.848135, 115);

    -- Insert 29
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (129, 'The Name of Mary Church', 'Landmark church in Novi Sad', 'assets/images/tour11.jpg', 45.257169, 19.846578, 115);

    -- Insert 30
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (130, 'Dunavska Street', 'Historic street in the city center', 'assets/images/tour12.jpg', 45.254316, 19.845824, 116);

    -- Insert 31
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (131, 'City Hall', 'Government building in Novi Sad', 'assets/images/tour12.jpg', 45.255726, 19.845021, 116);

    -- Insert 32
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (132, 'Zmaj Jovina Street', 'Pedestrian zone with shops and cafes', 'assets/images/tour13.jpg', 45.253635, 19.842817, 117);

    -- Insert 33
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (133, 'Serbian National Theatre', 'Cultural institution in Novi Sad', 'assets/images/tour13.jpg', 45.251894, 19.843656, 117);

    -- Insert 34
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (134, 'Petrovaradinska tvrdjava', 'Mjesto sa kojeg imate sjajan pogled na rijeku Dunav kao i sam Novi Sad', 'assets/images/tour11.jpg', 45.253070, 19.872268, 118);

    -- Insert 35
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (135, 'Centar', 'Obilazak centra grada gdje se pruza prilika da osjetite pravi duh samog grada', 'assets/images/tour11.jpg', 45.255836, 19.845573, 118);

    -- Insert 36
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (136, 'Dunavski park', 'Park u centru grada', 'assets/images/tour14.jpg', 45.249376, 19.848135, 119);

    -- Insert 37
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (137, 'Avala', 'Sjajan vidikovac', 'assets/images/tour8.jpg', 45.208352, 20.624540, 119);

    -- Insert 38
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (138, 'Trg Slobode', 'Central square in Novi Sad', 'assets/images/tour15.jpg', 45.251232, 19.836311, 120);

    -- Insert 39
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (139, 'Dunavski kej', 'Promenade along the Danube River', 'assets/images/tour15.jpg', 45.259963, 19.828440, 120);

    -- Insert 40
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (140, 'Fruška Gora National Park', 'Nature reserve and national park near Novi Sad', 'assets/images/tour16.jpg', 45.191910, 19.879249, 121);

    -- Insert 41
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (141, 'Trg Slobode', 'Central square in Novi Sad', 'assets/images/tour16.jpg', 45.251232, 19.836311, 121);

    -- Insert 42
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (142, 'Dunavski kej', 'Promenade along the Danube River', 'assets/images/tour17.jpg', 45.259963, 19.828440, 122);

    -- Insert 43
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (143, 'Fruška Gora National Park', 'Nature reserve and national park near Novi Sad', 'assets/images/tour17.jpg', 45.191910, 19.879249, 122);

    -- Insert 44
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (144, 'Petrovaradin Fortress', 'Historical fortress on the right bank of the Danube', 'assets/images/tour18.jpg', 45.253070, 19.872268, 123);

    -- Insert 45
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (145, 'Svetozar Miletic Square', 'Main square in Novi Sad', 'assets/images/tour18.jpg', 45.255836, 19.845573, 123);

    -- Insert 46
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (146, 'Danube Park', 'Park along the Danube River', 'assets/images/tour19.jpg', 45.249376, 19.848135, 124);

    -- Insert 47
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (147, 'The Name of Mary Church', 'Landmark church in Novi Sad', 'assets/images/tour19.jpg', 45.257169, 19.846578, 124);

    -- Insert 48
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (148, 'Dunavska Street', 'Historic street in the city center', 'assets/images/tour20.jpg', 45.254316, 19.845824, 125);

    -- Insert 49
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (149, 'City Hall', 'Government building in Novi Sad', 'assets/images/tour20.jpg', 45.255726, 19.845021, 125);

    -- Insert 50
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (150, 'Zmaj Jovina Street', 'Pedestrian zone with shops and cafes', 'assets/images/tour21.jpg', 45.253635, 19.842817, 126);

    -- Insert 51
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (151, 'Serbian National Theatre', 'Cultural institution in Novi Sad', 'assets/images/tour22.jpg', 45.251894, 19.843656, 126);

    -- Insert 52
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (152, 'Petrovaradinska tvrdjava', 'Mjesto sa kojeg imate sjajan pogled na rijeku Dunav kao i sam Novi Sad', 'assets/images/tour22.jpg', 45.253070, 19.872268, 127);

    -- Insert 53
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (153, 'Centar', 'Obilazak centra grada gdje se pruza prilika da osjetite pravi duh samog grada', 'assets/images/tour22.jpg', 45.255836, 19.845573, 127);

    -- Insert 54
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (154, 'Dunavski park', 'Park u centru grada', 'assets/images/tour23.jpg', 45.249376, 19.848135, 128);

    -- Insert 55
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (155, 'Avala', 'Sjajan vidikovac', 'assets/images/tour23.jpg', 45.208352, 20.624540, 128);

    -- Insert 56
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (156, 'Trg Slobode', 'Central square in Novi Sad', 'assets/images/tour24.jpg', 45.251232, 19.836311, 129);

    -- Insert 57
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (157, 'Dunavski kej', 'Promenade along the Danube River', 'assets/images/tour24.jpg', 45.259963, 19.828440, 129);

    -- Insert 58
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (158, 'Fruška Gora National Park', 'Nature reserve and national park near Novi Sad', 'assets/images/tour25.jpg', 45.191910, 19.879249, 130);

    -- Insert 59
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (159, 'Petrovaradin Fortress', 'Historical fortress on the right bank of the Danube', 'assets/images/tour26.jpg', 45.253070, 19.872268, 130);

    -- Insert 60
    INSERT INTO tours."Checkpoints"(
        "Id", "Name", "Description", "PictureURL", "Coordinates_Latitude", "Coordinates_Longitude", "TourId")
    VALUES (160, 'Svetozar Miletic Square', 'Main square in Novi Sad', 'assets/images/tour32.jpg', '45.255836', '19.845573', 130);



--EQUIPMENT
    INSERT INTO tours."Equipment"(
    "Id", "Name", "Description")
        VALUES (101, 'Voda', 'Količina vode varira od temperature i trajanja ture. Preporuka je da se pije pola litre vode na jedan sat umerena fizičke aktivnosti (npr. hajk u prirodi bez značajnog uspona) po umerenoj vrućini');
    INSERT INTO tours."Equipment"(
        "Id", "Name", "Description")
        VALUES (102, 'Štapovi za šetanje', 'Štapovi umanjuju umor nogu, pospešuju aktivnost gornjeg dela tela i pružaju stabilnost na neravnom terenu.');

    INSERT INTO tours."Equipment"(
        "Id", "Name", "Description")
        VALUES (103, 'Obična baterijska lampa', 'Baterijska lampa od 200 do 400 lumena.');


   --TOUR PREFERENCES
     INSERT INTO tours."TourPreferences"(
         "Id", "TouristId", "TourDifficult", "TourTravelMethod", "Rating", "Tags")
         VALUES (101, 105, 1, 1, 1, 'adventure, culture');

     INSERT INTO tours."TourPreferences"(
         "Id", "TouristId", "TourDifficult", "TourTravelMethod", "Rating", "Tags")
         VALUES (102, 106, 2, 2, 2, 'culture, diving');

    INSERT INTO tours."TourPreferences"(
         "Id", "TouristId", "TourDifficult", "TourTravelMethod", "Rating", "Tags")
         VALUES (103, 107, 2, 2, 2, 'skiing, adventure');
         


 --TOUR RATING
     INSERT INTO tours."TourRating"(
     "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
     VALUES 
         (101, 105, 5, 'Great tour!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-14T08:00:00');

     INSERT INTO tours."TourRating"(
         "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
     VALUES 
         (102, 106, 4, 'Enjoyed the tour.', CURRENT_TIMESTAMP - INTERVAL '3 days', 80, '2023-11-14T09:30:00');

     INSERT INTO tours."TourRating"(
         "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
     VALUES 
         (103, 107, 3, 'Could be better.', CURRENT_TIMESTAMP - INTERVAL '3 days', 50, '2023-11-14T11:15:00');

    -- Insert 4
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (104, 105, 4, 'Fantastic experience!', CURRENT_TIMESTAMP - INTERVAL '3 days', 90, '2023-11-15T10:45:00');
    
    -- Insert 5
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (105, 106, 5, 'Unforgettable journey!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-15T12:30:00');

    -- Insert 6
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 107, 3, 'Average experience.', CURRENT_TIMESTAMP - INTERVAL '3 days', 60, '2023-11-15T14:20:00');

    -- Insert 7
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 105, 4, 'Enjoyed the sights!', CURRENT_TIMESTAMP - INTERVAL '3 days', 80, '2023-11-16T09:15:00');

    -- Insert 8
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (108, 106, 5, 'Absolutely amazing!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-16T11:00:00');

    -- Insert 9
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (109, 107, 3, 'Needs improvement.', CURRENT_TIMESTAMP - INTERVAL '3 days', 50, '2023-11-16T13:45:00');

    -- Insert 10
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (110, 105, 4, 'Well organized tour.', CURRENT_TIMESTAMP - INTERVAL '3 days', 90, '2023-11-17T10:30:00');

    -- Insert 11
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (111, 106, 5, 'Thrilling adventure!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-17T12:15:00');

    -- Insert 12
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (112, 107, 3, 'Not as expected.', CURRENT_TIMESTAMP - INTERVAL '3 days', 60, '2023-11-17T14:00:00');

    -- Insert 13
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 105, 4, 'Fantastic scenery!', CURRENT_TIMESTAMP - INTERVAL '3 days', 80, '2023-11-18T09:45:00');

    -- Insert 14
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (114, 106, 5, 'Best tour ever!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-18T11:30:00');

    -- Insert 15
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (115, 107, 3, 'Could have been better.', CURRENT_TIMESTAMP - INTERVAL '3 days', 50, '2023-11-18T13:15:00');

    -- Insert 16
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (116, 105, 4, 'Impressive historical tour!', CURRENT_TIMESTAMP - INTERVAL '3 days', 90, '2023-11-19T10:00:00');

    -- Insert 17
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (117, 106, 5, 'Sailing was incredible!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-19T11:45:00');

    -- Insert 18
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (118, 107, 3, 'Cultural experience was lacking.', CURRENT_TIMESTAMP - INTERVAL '3 days', 60, '2023-11-19T13:30:00');

    -- Insert 19
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (119, 105, 4, 'Wildlife safari exceeded expectations!', CURRENT_TIMESTAMP - INTERVAL '3 days', 80, '2023-11-20T09:15:00');

    -- Insert 20
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (120, 106, 5, 'Breathtaking views from the hot air balloon!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-20T11:00:00');

    -- Insert 21
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (121, 105, 4, 'Wine tasting was delightful!', CURRENT_TIMESTAMP - INTERVAL '3 days', 90, '2023-11-21T10:45:00');

    -- Insert 22
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (122, 106, 5, 'Fishing expedition was a great experience!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-21T12:30:00');

    -- Insert 23
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (123, 107, 3, 'City exploration was just okay.', CURRENT_TIMESTAMP - INTERVAL '3 days', 60, '2023-11-21T14:20:00');

    -- Insert 24
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (124, 105, 4, 'Paragliding adventure was thrilling!', CURRENT_TIMESTAMP - INTERVAL '3 days', 80, '2023-11-22T09:15:00');

    -- Insert 25
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (125, 106, 5, 'Cultural experience was eye-opening!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-22T11:00:00');

    -- Insert 26
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (126, 107, 3, 'Gastronomic tour was average.', CURRENT_TIMESTAMP - INTERVAL '3 days', 50, '2023-11-22T13:45:00');

    -- Insert 27
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (127, 105, 4, 'Zip line adventure was heart-pounding!', CURRENT_TIMESTAMP - INTERVAL '3 days', 90, '2023-11-23T10:30:00');

    -- Insert 28
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (128, 106, 5, 'Rock climbing expedition was a challenge!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-11-23T12:15:00');

    -- Insert 29
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (129, 107, 3, 'Dolphin watching was disappointing.', CURRENT_TIMESTAMP - INTERVAL '3 days', 60, '2023-11-23T14:00:00');

   -- Additional ratings for TourId 102
    -- Insert 41
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (102, 105, 4, 'Interesting historical facts.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 85, '2023-11-27T14:30:00');

    -- Insert 42
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (102, 106, 3, 'Could be more interactive.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-11-27T15:45:00');

    -- Insert 43
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (102, 107, 5, 'Fascinating journey through history!', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-11-27T17:00:00');

    -- Insert 44
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (102, 105, 4, 'Well-preserved historical sites.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 90, '2023-11-28T10:15:00');

    -- Insert 45
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (102, 106, 5, 'Engaging storytelling by the guide.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-11-28T11:30:00');

    -- Insert 46
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (102, 107, 3, 'Expected more artifacts.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 50, '2023-11-28T13:45:00');

    -- Insert 47
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (102, 105, 4, 'Great learning experience.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-11-29T09:15:00');

    -- Insert 48
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (102, 106, 5, 'Memorable journey into the past!', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-11-29T10:30:00');

    -- Additional ratings for TourId 103
    -- Insert 49
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (103, 105, 3, 'Interesting but lacking excitement.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-11-29T11:45:00');

    -- Insert 50
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (103, 106, 4, 'Decent historical tour.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-11-29T13:00:00');

    -- Insert 51
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (103, 107, 5, 'Immersive journey through the past!', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-11-30T14:15:00');

    -- Insert 52
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (103, 105, 3, 'Expected more historical insights.', CURRENT_TIMESTAMP - INTERVAL '3 days', 50, '2023-11-30T15:30:00');

    -- Insert 53
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (103, 106, 4, 'Good overview of the historical period.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 75, '2023-11-30T16:45:00');

    -- Insert 54
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (103, 107, 5, 'Captivating stories from the past!', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-12-01T18:00:00');

    -- Insert 55
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (103, 105, 3, 'Historical tour with room for improvement.', CURRENT_TIMESTAMP - INTERVAL '3 days', 55, '2023-12-01T19:15:00');

    -- Additional ratings for TourId 104
    -- Insert 56
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (104, 106, 4, 'Incredible architectural wonders.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 85, '2023-12-01T20:30:00');

    -- Insert 57
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (104, 107, 5, 'Architectural marvels from different eras!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-12-02T21:45:00');

    -- Insert 58
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (104, 105, 3, 'Expected more historical insights.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-12-02T23:00:00');

    -- Insert 59
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (104, 106, 4, 'Informative tour about architectural history.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-12-03T12:15:00');

    -- Insert 60
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (104, 107, 5, 'Fascinating stories behind the structures!', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-12-03T13:30:00');

    -- Insert 61
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (104, 105, 3, 'Architectural tour with room for improvement.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 50, '2023-12-03T14:45:00');

    -- Insert 62
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (104, 106, 4, 'Well-organized tour with knowledgeable guide.', CURRENT_TIMESTAMP - INTERVAL '3 days', 90, '2023-12-04T16:00:00');

    -- Additional ratings for TourId 105
    -- Insert 63
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (105, 107, 5, 'Spectacular natural beauty!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-12-04T17:15:00');

    -- Insert 64
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (105, 105, 3, 'Expected more wildlife sightings.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-12-04T18:30:00');

    -- Insert 65
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (105, 106, 4, 'Breathtaking views from the mountain peak.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-12-05T19:45:00');

    -- Insert 66
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (105, 107, 5, 'Nature walk was a peaceful experience!', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-12-05T21:00:00');

    -- Insert 67
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (105, 105, 3, 'Wildlife tour with room for improvement.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 50, '2023-12-05T22:15:00');

    -- Insert 68
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (105, 106, 4, 'Well-guided bird watching expedition.', CURRENT_TIMESTAMP - INTERVAL '3 days', 90, '2023-12-06T23:30:00');

    -- Insert 69
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (105, 107, 5, 'Sunset views from the hilltop were magical!', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-12-06T14:45:00');

    -- Additional ratings for TourId 106
    -- Insert 70
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 105, 3, 'Average experience with hot air balloon.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-12-07T16:00:00');

    -- Insert 71
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 106, 4, 'Panoramic views of the landscape.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-12-07T17:15:00');
    -- Insert 72
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 107, 5, 'Absolutely breathtaking!', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-12-07T18:30:00');

    -- Insert 73
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 105, 3, 'Weather conditions impacted experience.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-12-08T10:00:00');

    -- Insert 74
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 106, 4, 'Morning flight offered stunning sunrise views.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-12-08T11:30:00');

    -- Insert 75
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 107, 5, 'Peaceful experience floating in the air.', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-12-08T13:00:00');

    -- Insert 76
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 105, 3, 'Hot air balloon ride was shorter than expected.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-12-09T09:45:00');

    -- Insert 77
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 106, 4, 'Landscapes looked magical from above.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-12-09T11:15:00');

    -- Insert 78
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 107, 5, 'Highly recommended for a unique experience.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-12-09T12:45:00');

    -- Insert 79
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 105, 3, 'Balloon ride was affected by strong winds.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-12-10T10:30:00');

    -- Insert 80
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (106, 106, 4, 'Captivating views of the landscape.', CURRENT_TIMESTAMP - INTERVAL '3 days', 80, '2023-12-10T12:00:00');


    -- Additional ratings for TourId 107
    -- Insert 81
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 105, 3, 'City tour was average.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-12-07T16:00:00');

    -- Insert 82
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 106, 4, 'Historical sites were interesting.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-12-07T17:15:00');

    -- Insert 83
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 107, 5, 'Knowledgeable guide made the tour enjoyable.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-12-07T18:30:00');

    -- Insert 84
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 105, 3, 'City exploration lacked variety.', CURRENT_TIMESTAMP - INTERVAL '3 days', 60, '2023-12-08T10:00:00');

    -- Insert 85
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 106, 4, 'Insightful tour of local culture.', CURRENT_TIMESTAMP - INTERVAL '3 days', 80, '2023-12-08T11:30:00');

    -- Insert 86
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 107, 5, 'Enjoyed the city architecture.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 100, '2023-12-08T13:00:00');

    -- Insert 87
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 105, 3, 'City tour was affected by traffic.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 60, '2023-12-09T09:45:00');

    -- Insert 88
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 106, 4, 'Interesting stories about the city history.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-12-09T11:15:00');

    -- Insert 89
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 107, 5, 'City tour provided a unique perspective.', CURRENT_TIMESTAMP - INTERVAL '3 days', 100, '2023-12-09T12:45:00');

    -- Insert 90
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 105, 3, 'City exploration was impacted by weather.', CURRENT_TIMESTAMP - INTERVAL '3 days', 60, '2023-12-10T10:30:00');

    -- Insert 91
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (107, 106, 4, 'City landmarks were well-explained.', CURRENT_TIMESTAMP - INTERVAL '3 weeks', 80, '2023-12-10T12:00:00');

    -- Additional ratings for TourId 111
     -- Insert 92
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (111, 111, 5, 'City landmarks were well-explained.', CURRENT_TIMESTAMP - INTERVAL '3 days', 80, '2023-12-10T12:00:00');

    -- Insert 93
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (111, 112, 4, 'Enjoyed the historical sites.', CURRENT_TIMESTAMP - INTERVAL '2 days', 85, '2023-12-11T14:30:00');

    -- Insert 94
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (111, 113, 5, 'Amazing experience!', CURRENT_TIMESTAMP - INTERVAL '2 days', 90, '2023-12-11T16:45:00');

    -- Insert 95
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (111, 114, 4, 'The guide was very knowledgeable.', CURRENT_TIMESTAMP - INTERVAL '1 day', 88, '2023-12-12T10:15:00');

    -- Insert 96
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (111, 115, 5, 'Highly recommended!', CURRENT_TIMESTAMP - INTERVAL '1 day', 92, '2023-12-12T12:30:00');

    -- Insert 97
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (112, 116, 4, 'Interesting sights along the way.', CURRENT_TIMESTAMP - INTERVAL '2 days', 85, '2023-12-11T14:30:00');

    -- Insert 98
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (112, 117, 5, 'Fantastic tour!', CURRENT_TIMESTAMP - INTERVAL '1 day', 90, '2023-12-12T10:15:00');

    -- Insert 99
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (112, 118, 4, 'Enjoyed the cultural experience.', CURRENT_TIMESTAMP - INTERVAL '1 day', 88, '2023-12-12T12:30:00');

    -- Insert 100
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 119, 5, 'Absolutely incredible!', CURRENT_TIMESTAMP - INTERVAL '2 days', 95, '2023-12-11T14:30:00');

    -- Insert 101
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 120, 4, 'Best tour ever!', CURRENT_TIMESTAMP - INTERVAL '1 day', 98, '2023-12-12T10:15:00');

    -- Insert 102
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 111, 5, 'Wonderful experience!', CURRENT_TIMESTAMP - INTERVAL '1 day', 96, '2023-12-12T12:30:00');

    -- Insert 103
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 112, 5, 'Highly recommended!', CURRENT_TIMESTAMP - INTERVAL '1 day', 99, '2023-12-12T14:45:00');

    -- Insert 104
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 113, 4, 'Fantastic tour guide!', CURRENT_TIMESTAMP - INTERVAL '1 day', 97, '2023-12-12T17:00:00');

    -- Insert 105
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 114, 5, 'Great historical insights.', CURRENT_TIMESTAMP - INTERVAL '1 day', 95, '2023-12-12T19:15:00');

    -- Insert 106
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 115, 5, 'Memorable tour experience.', CURRENT_TIMESTAMP - INTERVAL '1 day', 98, '2023-12-12T21:30:00');

    -- Insert 107
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 116, 5, 'Thoroughly enjoyed every moment.', CURRENT_TIMESTAMP - INTERVAL '1 day', 96, '2023-12-12T23:45:00');

    -- Insert 108
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 117, 5, 'Excellent tour guide and itinerary.', CURRENT_TIMESTAMP, 99, '2023-12-13T02:00:00');

    -- Insert 109
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 118, 5, 'A must-do tour!', CURRENT_TIMESTAMP, 100, '2023-12-13T04:15:00');

    -- Insert 110
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 119, 5, 'Unforgettable experience.', CURRENT_TIMESTAMP, 98, '2023-12-13T06:30:00');

    -- Insert 111
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (113, 120, 5, 'Well-organized and informative.', CURRENT_TIMESTAMP, 97, '2023-12-13T08:45:00');

    -- TourId 115
    -- Insert 112
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (115, 111, 4, 'Great tour, loved the scenery!', CURRENT_TIMESTAMP - INTERVAL '2 days', 88, '2023-12-11T14:30:00');

    -- Insert 113
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (115, 112, 5, 'Fantastic historical sites.', CURRENT_TIMESTAMP - INTERVAL '2 days', 92, '2023-12-11T16:45:00');

    -- Insert 114
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (115, 113, 3, 'Some parts were less interesting.', CURRENT_TIMESTAMP - INTERVAL '1 day', 80, '2023-12-12T10:15:00');

    -- Insert 115
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (115, 114, 4, 'Overall, a good experience.', CURRENT_TIMESTAMP - INTERVAL '1 day', 85, '2023-12-12T12:30:00');


    -- TourId 116
    -- Insert 116
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (116, 115, 5, 'Incredible tour guide!', CURRENT_TIMESTAMP - INTERVAL '2 days', 90, '2023-12-11T14:30:00');

    -- Insert 117
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (116, 116, 3, 'Some parts were less than expected.', CURRENT_TIMESTAMP - INTERVAL '1 day', 75, '2023-12-12T10:15:00');

    -- Insert 118
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (116, 117, 4, 'Enjoyed the cultural insights.', CURRENT_TIMESTAMP, 85, '2023-12-13T02:00:00');


    -- TourId 118
    -- Insert 119
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (118, 118, 5, 'Absolutely amazing!', CURRENT_TIMESTAMP - INTERVAL '2 days', 95, '2023-12-11T14:30:00');

    -- Insert 120
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (118, 119, 4, 'Well-organized tour.', CURRENT_TIMESTAMP - INTERVAL '1 day', 88, '2023-12-12T10:15:00');

    -- Insert 121
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (118, 120, 3, 'Some parts could be improved.', CURRENT_TIMESTAMP, 75, '2023-12-13T02:00:00');

    -- Insert 122
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (118, 111, 5, 'Highly recommended!', CURRENT_TIMESTAMP, 98, '2023-12-13T04:15:00');

    -- TourId 121
    -- Insert 123
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (121, 112, 5, 'Incredible tour, loved every moment!', CURRENT_TIMESTAMP - INTERVAL '2 days', 95, '2023-12-11T14:30:00');

    -- Insert 124
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (121, 113, 5, 'Fantastic experience!', CURRENT_TIMESTAMP - INTERVAL '1 day', 98, '2023-12-12T10:15:00');

    -- Insert 125
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (121, 114, 5, 'Highly recommended!', CURRENT_TIMESTAMP, 100, '2023-12-13T02:00:00');

    -- Insert 126
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (121, 115, 5, 'Memorable tour!', CURRENT_TIMESTAMP, 98, '2023-12-13T04:15:00');

    -- Insert 127
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (121, 116, 4, 'Great tour, but some improvements possible.', CURRENT_TIMESTAMP, 85, '2023-12-13T06:30:00');


    -- TourId 123
    -- Insert 128
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (123, 117, 4, 'Enjoyed the tour!', CURRENT_TIMESTAMP - INTERVAL '2 days', 88, '2023-12-11T14:30:00');

    -- Insert 129
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (123, 118, 4, 'Well-organized and informative.', CURRENT_TIMESTAMP - INTERVAL '1 day', 88, '2023-12-12T10:15:00');


    -- TourId 124
    -- Insert 130
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (124, 119, 4, 'Good tour overall.', CURRENT_TIMESTAMP - INTERVAL '2 days', 85, '2023-12-11T14:30:00');

    -- Insert 131
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (124, 120, 5, 'Excellent guide and sights!', CURRENT_TIMESTAMP - INTERVAL '1 day', 95, '2023-12-12T10:15:00');

    -- TourId 125
    -- Insert 132
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (125, 111, 5, 'Great tour, highly recommended!', CURRENT_TIMESTAMP - INTERVAL '2 days', 92, '2023-12-11T14:30:00');


    -- TourId 126
    -- Insert 133
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (126, 112, 5, 'Fantastic experience!', CURRENT_TIMESTAMP - INTERVAL '1 day', 96, '2023-12-12T10:15:00');


    -- TourId 127
    -- Insert 134
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (127, 113, 5, 'Incredible tour guide!', CURRENT_TIMESTAMP - INTERVAL '2 days', 90, '2023-12-11T14:30:00');

    -- Insert 135
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (127, 114, 5, 'Best tour I have ever been on!', CURRENT_TIMESTAMP - INTERVAL '1 day', 98, '2023-12-12T10:15:00');

    -- Insert 136
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (127, 115, 5, 'Absolutely amazing!', CURRENT_TIMESTAMP, 100, '2023-12-13T02:00:00');

    -- Insert 137
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (127, 116, 5, 'Great historical insights.', CURRENT_TIMESTAMP, 98, '2023-12-13T04:15:00');

    -- Insert 138
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (127, 117, 5, 'Wonderful experience!', CURRENT_TIMESTAMP, 96, '2023-12-13T06:30:00');

    -- Insert 139
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (127, 118, 5, 'Highly recommended!', CURRENT_TIMESTAMP, 99, '2023-12-13T08:45:00');


    -- TourId 128
    -- Insert 140
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (128, 119, 4, 'Good tour overall.', CURRENT_TIMESTAMP - INTERVAL '2 days', 85, '2023-12-11T14:30:00');

    -- Insert 141
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (128, 120, 4, 'Well-organized and informative.', CURRENT_TIMESTAMP - INTERVAL '1 day', 88, '2023-12-12T10:15:00');

    -- Insert 142
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (128, 111, 3, 'Some parts were less interesting.', CURRENT_TIMESTAMP, 75, '2023-12-13T02:00:00');

    -- Insert 143
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (128, 112, 3, 'Not bad, but could be better.', CURRENT_TIMESTAMP, 78, '2023-12-13T04:15:00');

    -- Insert 144
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (128, 113, 4, 'Enjoyed the cultural insights.', CURRENT_TIMESTAMP, 85, '2023-12-13T06:30:00');

    -- TourId 129
    -- Insert 145
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (129, 114, 5, 'Fantastic tour guide!', CURRENT_TIMESTAMP - INTERVAL '2 days', 92, '2023-12-11T14:30:00');

    -- Insert 146
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (129, 115, 4, 'Good overall, but some improvements possible.', CURRENT_TIMESTAMP - INTERVAL '1 day', 80, '2023-12-12T10:15:00');


    -- TourId 130
    -- Insert 147
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (130, 116, 5, 'Incredible experience!', CURRENT_TIMESTAMP - INTERVAL '2 days', 95, '2023-12-11T14:30:00');

    -- Insert 148
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (130, 117, 5, 'Best tour ever!', CURRENT_TIMESTAMP - INTERVAL '1 day', 98, '2023-12-12T10:15:00');

    -- Insert 149
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (130, 118, 5, 'Absolutely amazing!', CURRENT_TIMESTAMP, 100, '2023-12-13T02:00:00');

    -- Insert 150
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (130, 119, 5, 'Memorable tour!', CURRENT_TIMESTAMP, 98, '2023-12-13T04:15:00');

    -- Insert 151
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (130, 120, 5, 'Great historical insights.', CURRENT_TIMESTAMP, 96, '2023-12-13T06:30:00');

    -- Insert 152
    INSERT INTO tours."TourRating"(
        "TourId", "TouristId", "Rating", "Review", "Created", "CompletionPercentage", "LastActivity")
    VALUES 
        (130, 111, 5, 'Wonderful experience!', CURRENT_TIMESTAMP, 99, '2023-12-13T08:45:00');



 --DESTINATIONS
     INSERT INTO tours."Destinations"(
         "Id", "PersonId", "Longitude", "Latitude", "Name", "Description", "ImageURL", "Type")
         VALUES (101, 102, 19.83790160507586, 45.25134430879981, 'Tortilla Casa', 'Meksička kuhinja', 'dcce1254-fa04-4769-986d-8fcc0b07731c_tortilla.png', 1);
     INSERT INTO tours."Destinations"(
         "Id", "PersonId", "Longitude", "Latitude", "Name", "Description", "ImageURL", "Type")
         VALUES (102, 102, 19.83948381596105, 45.251071913393545, 'Parking garaža', 'Plaćeni parking centar', '5b52ffb1-1178-4e38-b808-a1cbc2961599_parking.jpg', 2);
     INSERT INTO tours."Destinations"(
         "Id", "PersonId", "Longitude", "Latitude", "Name", "Description", "ImageURL", "Type")
         VALUES (103, 102, 19.843240522266168, 45.2452640137409, 'Promenada', 'Tržni centar', 'ca433b67-f5a5-447a-b331-93b2afbd8ebd_promenada.jpg', 0);



 --REPORTS
     INSERT INTO tours."Reports"(
         "Id", "Category", "Priority", "Description", "DateCreated")
         VALUES (101, 'Vodic', 2, 'Vodic se nije pojavio na turi.', '2023-10-24T12:18:34.171Z');

     INSERT INTO tours."Reports"(
         "Id", "Category", "Priority", "Description", "DateCreated")
         VALUES (102, 'Vodic', 2, 'Vodic je kasnio na turu.', '2023-10-24T12:18:34.171Z');

--TOUR EXECUTIONS
    -- Insert 1
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (101, 105, 101, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 1.2, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 101, 'CompletionTime', null),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 102, 'CompletionTime', null),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 103, 'CompletionTime', null)
        ));

    -- Insert 2
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (102, 106, 101, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 2.3, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 101, 'CompletionTime', null),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 102, 'CompletionTime', null),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 103, 'CompletionTime', null)
        ));

    -- Insert 3
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (103, 107, 101, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 0.6, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 101, 'CompletionTime', null),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 102, 'CompletionTime', null),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 103, 'CompletionTime', null)
        ));

    -- Insert 4
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (104, 118, 101, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '1 days', 1, 1.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 101, 'CompletionTime', '2023-11-07T11:47:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 102, 'CompletionTime', '2023-11-07T11:55:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 103, 'CompletionTime', '2023-11-07T12:00:25.421614+01:00')
        ));

    -- Insert 5
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (105, 105, 102, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 1.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 104, 'CompletionTime', '2023-11-07T11:47:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 105, 'CompletionTime', '2023-11-07T11:55:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 106, 'CompletionTime', '2023-11-07T12:00:25.421614+01:00')
        ));

    -- Insert 6
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (106, 105, 105, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '6 hours', 1, 2.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 108, 'CompletionTime', '2023-11-07T12:15:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 109, 'CompletionTime', '2023-11-07T12:25:25.421614+01:00')
        ));

    -- Insert 7
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (107, 106, 102, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '2 days', 1, 1.3, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 104, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 105, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 106, 'CompletionTime', NULL)
        ));

    -- Insert 8
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (108, 105, 106, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '1 days', 1, 3.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 110, 'CompletionTime', '2023-11-07T13:45:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 111, 'CompletionTime', '2023-11-07T13:55:25.421614+01:00')
        ));

    -- Insert 9
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (109, 105, 103, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 4.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 107, 'CompletionTime', '2023-11-07T14:45:25.421614+01:00')
        ));

    -- Insert 10
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (110, 106, 103, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '11 days', 2, 3.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 107, 'CompletionTime', '2023-11-07T15:15:25.421614+01:00')
        ));

    -- Insert 11
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (111, 105, 112, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '6 days', 2, 0.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 122, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 123, 'CompletionTime', NULL)
        ));

    -- Insert 12
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (112, 106, 104, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '2 days', 1, 2.0, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 108, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 109, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 110, 'CompletionTime', NULL)
        ));

    -- Insert 13
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (113, 105, 113, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 2.1, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 124, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 125, 'CompletionTime', NULL)
        ));

    -- Insert 14
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (114, 105, 114, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days 12 hours', 2, 0.7, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 126, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 127, 'CompletionTime', NULL)
        ));

    -- Insert 15
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (115, 105, 115, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 5.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 128, 'CompletionTime', '2023-11-07T19:45:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 129, 'CompletionTime', '2023-11-07T19:55:25.421614+01:00')
        ));

    -- Insert 16
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (116, 105, 116, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 3.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 130, 'CompletionTime', '2023-11-07T20:15:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 131, 'CompletionTime', '2023-11-07T20:25:25.421614+01:00')
        ));

    -- Insert 17
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (117, 105, 118, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 1.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 134, 'CompletionTime', '2023-11-07T20:45:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 135, 'CompletionTime', '2023-11-07T20:45:25.421614+01:00')
        ));

    -- Insert 18
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (118, 106, 107, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '1 days', 1, 1.7, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 118, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 119, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 120, 'CompletionTime', NULL)
        ));

    -- Insert 19
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES (119, 105, 130, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '2 days', 1, 5.3, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 158, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 159, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 160, 'CompletionTime', NULL)
        ));

    -- Insert 20
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (120, 106, 102, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '2 days', 1, 3.2, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 104, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 105, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 106, 'CompletionTime', NULL)
        ));

    -- Insert 21
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (121, 107, 105, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '3 days', 2, 1.8, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 108, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 109, 'CompletionTime', NULL)
        ));

    -- Insert 22
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (122, 108, 105, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '4 days', 1, 4.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 108, 'CompletionTime', '2023-11-07T13:45:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 109, 'CompletionTime', '2023-11-07T13:55:25.421614+01:00')
        ));

    -- Insert 23
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (123, 109, 105, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '2 days', 1, 2.3, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 108, 'CompletionTime', '2023-11-07T12:15:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 109, 'CompletionTime', '2023-11-07T12:25:25.421614+01:00')
        ));

    -- Insert 24
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (124, 107, 106, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '1 days', 1, 0.9, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 110, 'CompletionTime', '2023-11-07T13:45:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 111, 'CompletionTime', '2023-11-07T13:55:25.421614+01:00')
        ));

    -- Insert 25
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (125, 111, 107, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 3.2, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 112, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 113, 'CompletionTime', NULL)
        ));

    -- Insert 26
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (126, 111, 108, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '3 days', 2, 2.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 114, 'CompletionTime', '2023-11-07T20:45:25.421614+01:00'),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 115, 'CompletionTime', '2023-11-07T20:45:25.421614+01:00')
        ));

    -- Insert 27
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (127, 105, 109, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '2 days', 1, 1.5, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 116, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 117, 'CompletionTime', NULL)
        ));

    -- Insert 28
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (128, 112, 110, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '1 days', 1, 4.7, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 118, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 119, 'CompletionTime', NULL)
        ));

    -- Insert 29
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (129, 115, 111, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '3 days', 1, 3.8, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 120, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', true, 'CheckpointId', 121, 'CompletionTime', NULL)
        ));

    -- Insert 30
    INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
    VALUES 
        (130, 109, 112, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '2 days', 1, 2.2, 
        jsonb_build_array(
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 122, 'CompletionTime', NULL),
            jsonb_build_object('IsCompleted', false, 'CheckpointId', 123, 'CompletionTime', NULL)
        ));



    -- COMPOSITE TOURS
    INSERT INTO tours."CompositeTours"("Id", "TouristId", "Name")
        VALUES (101, 105, 'Kompozitna tura1');

    INSERT INTO tours."CompositeTours"("Id", "TouristId", "Name")
        VALUES (102, 105, 'Kompozitna tura2');

    -- TOUR - COMPOSITE TOUR
    INSERT INTO tours."TourCompositeTour"("CompositeTourId", "ToursId")
        VALUES (101, 103);

    INSERT INTO tours."TourCompositeTour"("CompositeTourId", "ToursId")
        VALUES (101, 104);

    INSERT INTO tours."TourCompositeTour"("CompositeTourId", "ToursId")
        VALUES (102, 104);

    INSERT INTO tours."TourCompositeTour"("CompositeTourId", "ToursId")
        VALUES (101, 105);

    -- QUESTIONNAIRE
    INSERT INTO tours."Questionnaire"("Id","Question","Answer")
        VALUES(1,'Jel ima neko pusenje kurca ovde?' , 'Ima');
    INSERT INTO tours."Questionnaire"("Id","Question","Answer")
        VALUES(2,'Glavni grad Srbije' , 'Beograd');
    INSERT INTO tours."Questionnaire"("Id","Question","Answer")
        VALUES(3, 'Koja je glavna zgrada Vatikana?' , 'Sveti Petar');
    INSERT INTO tours."Questionnaire"("Id","Question","Answer")
        VALUES(4, 'Koje jezero je najdublje na svetu?' , 'Bajkalsko jezero');
    INSERT INTO tours."Questionnaire"("Id","Question","Answer")
        VALUES(5, 'Koji grad se često naziva "Grad svetlosti"?' , 'Pariz');
    INSERT INTO tours."Questionnaire"("Id","Question","Answer")
        VALUES(6, 'Koje mesto je bio epicentar Pompeje?' , 'Vesuv');
    INSERT INTO tours."Questionnaire"("Id","Question","Answer")
        VALUES(7, 'Gde se nalazi Tadž Mahal?' , 'Indija');


--BLOG SCHEMA
    --BLOGS
    INSERT INTO blog."Blogs"(
        "Id", "Name", "Description", "DateCreated", "Images", "AuthorId", "Status", "Rating", "Comments", "Ratings")
        VALUES (101, 'Turisticki Blog', 'Sve o turizmu na jednom mestu', '2023-10-17 17:12:31.426+02', 
            array['asdasd', 'asdasdasd'], 102, 1, 1, 
            '[{
            "UserId": 105,
            "Context": "komentar",
            "CreationTime": "2023-10-17 17:12:31.426+02",
            "LastUpdateTime": "2023-10-17 17:12:31.426+02"
        },
        {
            "UserId": 106,
            "Context": "komentar",
            "CreationTime": "2023-10-17 17:12:31.426+02",
            "LastUpdateTime": "2023-10-17 17:12:31.426+02"
        }]', 
        '[{
            "UserId": 105,
            "RatingType": 0
        }]');
    INSERT INTO blog."Blogs"(
        "Id", "Name", "Description", "DateCreated", "Images", "AuthorId", "Status", "Rating", "Comments", "Ratings")
        VALUES (102, 'Lovacki Blog', 'Sve o lovu na jednom mestu', '2022-10-17 17:12:31.426+02', 
            array['image2.jpg','image3.jpg'], 103, 1, 1, 
        '[{
            "UserId": 105,
            "Context": "komentar",
            "CreationTime": "2023-11-07 12:00:25.421614+01",
            "LastUpdateTime": "2023-11-07 12:00:25.421614+01"
        },
        {
            "UserId": 106,
            "Context": "komentar",
            "CreationTime": "2023-11-07 12:00:25.421614+01",
            "LastUpdateTime": "2023-11-07 12:00:25.421614+01"
        }]', 
        '[{
            "UserId": 105,
            "RatingType": 0
        }]');

--PAYMENTS SCHEMA
  

    -- WALLET
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (101 , 105 , 136);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (102 , 106 , 146);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (103 , 107 , 156);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (104 , 108 , 166);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (105 , 109 , 176);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (106 , 110 , 186);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (107, 111, 196);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (108, 112, 206);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (109, 113, 216);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (110, 114, 226);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (111, 115, 236);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (112, 116, 246);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (113, 117, 256);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (114, 118, 266);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (115, 119, 276);
    INSERT INTO payments."Wallet"("Id","UserId","AdventureCoins")
        VALUES (116, 120, 286);

    -- ORDERS
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (101, 105, 102, 200, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (102, 105, 103, 20, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (103, 105, 104, 30, '2023-12-05 14:36:28.257082+01');

-- Orders for Tour 105
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (104, 111, 105, 30, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (105, 112, 105, 30, '2023-12-05 14:36:28.257082+01');
    
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (106, 113, 105, 30, '2023-12-05 14:36:28.257082+01');
    
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (107, 114, 105, 30, '2023-12-05 14:36:28.257082+01');
    
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (108, 115, 105, 30, '2023-12-05 14:36:28.257082+01');
    
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (109, 116, 105, 30, '2023-12-05 14:36:28.257082+01');

-- Orders for Tour 106
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (110, 111, 106, 30, '2023-12-05 14:36:28.257082+01');
    
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (111, 112, 106, 30, '2023-12-05 14:36:28.257082+01');
    
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (112, 113, 106, 30, '2023-12-05 14:36:28.257082+01');
    
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (113, 114, 106, 30, '2023-12-05 14:36:28.257082+01');

-- Orders for Tour 107
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (114, 115, 107, 25, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (115, 116, 107, 25, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (116, 117, 107, 25, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (117, 118, 107, 25, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (118, 119, 107, 25, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (119, 120, 107, 25, '2023-12-05 14:36:28.257082+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (120, 111, 107, 25, '2023-12-05 14:36:28.257082+01');

-- Orders for Tour 108
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (121, 112, 108, 40, '2023-12-05 15:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (122, 113, 108, 40, '2023-12-05 15:01:00.000000+01');

-- Orders for Tour 109
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (123, 114, 109, 35, '2023-12-06 11:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (124, 115, 109, 35, '2023-12-06 11:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (125, 116, 109, 35, '2023-12-06 11:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (126, 117, 109, 35, '2023-12-06 11:03:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (127, 118, 109, 35, '2023-12-06 11:04:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (128, 119, 109, 35, '2023-12-06 11:05:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (129, 120, 109, 35, '2023-12-06 11:06:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (130, 111, 109, 35, '2023-12-06 11:07:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (131, 112, 109, 35, '2023-12-06 11:08:00.000000+01');


-- Orders for Tour 110
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (132, 113, 110, 45, '2023-12-06 12:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (133, 114, 110, 45, '2023-12-06 12:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (134, 115, 110, 45, '2023-12-06 12:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (135, 116, 110, 45, '2023-12-06 12:03:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (136, 117, 110, 45, '2023-12-06 12:04:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (137, 118, 110, 45, '2023-12-06 12:05:00.000000+01');

-- Orders for Tour 112
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (138, 119, 112, 55, '2023-12-07 13:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (139, 120, 112, 55, '2023-12-07 13:01:00.000000+01');

-- Orders for Tour 113
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (140, 111, 113, 65, '2023-12-07 14:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (141, 112, 113, 65, '2023-12-07 14:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (142, 113, 113, 65, '2023-12-07 14:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (143, 114, 113, 65, '2023-12-07 14:03:00.000000+01');

-- Orders for Tour 114
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (144, 115, 114, 75, '2023-12-07 15:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (145, 116, 114, 75, '2023-12-07 15:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (146, 117, 114, 75, '2023-12-07 15:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (147, 118, 114, 75, '2023-12-07 15:03:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (148, 119, 114, 75, '2023-12-07 15:04:00.000000+01');

-- Order for Tour 115
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (149, 120, 115, 40, '2023-12-08 16:00:00.000000+01');

-- Orders for Tour 116
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (150, 111, 116, 50, '2023-12-08 17:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (151, 112, 116, 50, '2023-12-08 17:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (152, 113, 116, 50, '2023-12-08 17:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (153, 114, 116, 50, '2023-12-08 17:03:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (154, 115, 116, 50, '2023-12-08 17:04:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (155, 116, 116, 50, '2023-12-08 17:05:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (156, 117, 116, 50, '2023-12-08 17:06:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (157, 118, 116, 50, '2023-12-08 17:07:00.000000+01');

-- Orders for Tour 118
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (158, 119, 118, 60, '2023-12-08 18:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (159, 120, 118, 60, '2023-12-08 18:01:00.000000+01');

-- Orders for Tour 119
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (160, 111, 119, 30, '2023-12-09 10:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (161, 112, 119, 30, '2023-12-09 10:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (162, 113, 119, 30, '2023-12-09 10:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (163, 114, 119, 30, '2023-12-09 10:03:00.000000+01');

-- Orders for Tour 120
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (164, 115, 120, 25, '2023-12-09 11:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (165, 116, 120, 25, '2023-12-09 11:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (166, 117, 120, 25, '2023-12-09 11:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (167, 118, 120, 25, '2023-12-09 11:03:00.000000+01');

-- Orders for Tour 121
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (168, 119, 121, 35, '2023-12-09 12:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (169, 120, 121, 35, '2023-12-09 12:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (170, 111, 121, 35, '2023-12-09 12:02:00.000000+01');

-- Orders for Tour 122
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (171, 112, 122, 45, '2023-12-10 14:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (172, 113, 122, 45, '2023-12-10 14:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (173, 114, 122, 45, '2023-12-10 14:02:00.000000+01');

-- Orders for Tour 123
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (174, 115, 123, 55, '2023-12-10 15:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (175, 116, 123, 55, '2023-12-10 15:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (176, 117, 123, 55, '2023-12-10 15:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (177, 118, 123, 55, '2023-12-10 15:03:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (178, 119, 123, 55, '2023-12-10 15:04:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (179, 120, 123, 55, '2023-12-10 15:05:00.000000+01');

-- Orders for Tour 124
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (180, 111, 124, 65, '2023-12-10 16:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (181, 112, 124, 65, '2023-12-10 16:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (182, 113, 124, 65, '2023-12-10 16:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (183, 114, 124, 65, '2023-12-10 16:03:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (184, 115, 124, 65, '2023-12-10 16:04:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (185, 116, 124, 65, '2023-12-10 16:05:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (186, 117, 124, 65, '2023-12-10 16:06:00.000000+01');

-- Order for Tour 125
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (187, 118, 125, 75, '2023-12-10 17:00:00.000000+01');

-- Orders for Tour 127
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (188, 119, 127, 40, '2023-12-11 11:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (189, 120, 127, 40, '2023-12-11 11:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (190, 111, 127, 40, '2023-12-11 11:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (191, 112, 127, 40, '2023-12-11 11:03:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (192, 113, 127, 40, '2023-12-11 11:04:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (193, 114, 127, 40, '2023-12-11 11:05:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (194, 115, 127, 40, '2023-12-11 11:06:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (195, 116, 127, 40, '2023-12-11 11:07:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (196, 117, 127, 40, '2023-12-11 11:08:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (197, 118, 127, 40, '2023-12-11 11:09:00.000000+01');

-- Orders for Tour 128
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (198, 119, 128, 50, '2023-12-11 12:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (199, 120, 128, 50, '2023-12-11 12:01:00.000000+01');

-- Orders for Tour 129
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (200, 111, 129, 60, '2023-12-11 13:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (201, 112, 129, 60, '2023-12-11 13:01:00.000000+01');

-- Orders for Tour 130
INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (202, 113, 130, 70, '2023-12-11 14:00:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (203, 114, 130, 70, '2023-12-11 14:01:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (204, 115, 130, 70, '2023-12-11 14:02:00.000000+01');

INSERT INTO payments."Orders"("Id", "UserId", "TourId", "Price", "PaymentTime")
    VALUES (205, 116, 130, 70, '2023-12-11 14:03:00.000000+01');


-- SHOPPING CART
-- SHOPPING CART
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (101, 105, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (102, 106, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (103, 107, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (104, 108, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (105, 109, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (106, 110, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (107, 111, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (108, 112, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (109, 113, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (110, 114, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (111, 115, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (112, 116, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (113, 117, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (114, 118, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (115, 119, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));
INSERT INTO payments."ShoppingCart"("Id", "UserId", "Items", "TourCoupon", "BundleItems")
    VALUES (116, 120, jsonb_build_array(jsonb_build_object()), null, jsonb_build_array(jsonb_build_object()));

--ENCOUNTERS SCHEMA
    --ENCOUNTERS
    INSERT INTO encounters."Encounters"(
        "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range", "SocialEncounterRequiredPeople")
        VALUES (101, 'Party at Novosadski Kej', 'Come hang out and link up with other people. ', '{"Latitude": 45.253755, "Longitude": 19.855750}', 15, 0, 0, 200, 15);
    INSERT INTO encounters."Encounters"(
        "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range", "ImageUrl")
        VALUES (102, 'Novi Sad Galleries', 'Explore galleries on top of the Petrovaridn Fort and find the picture from the image.', '{"Latitude": 45.2529552634461, "Longitude": 19.86110329627991}', 30, 0, 1, 300, 'c6423754-43a1-4b81-8850-ce7c3d598332_malcesineNnLakeGarda.png');
    INSERT INTO encounters."Encounters"(
        "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range", "MiscEncounterTask")
        VALUES (103, 'See the city from a different perspective', 'Feeling adventurous today? Hop on a bus ride and see where it takes you.', '{"Latitude": 45.26531607067374, "Longitude": 19.829609636217356}', 25, 0, 2, 300, 'Take a bus ride.');
    INSERT INTO encounters."Encounters"(
        "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range", "SocialEncounterRequiredPeople")
        VALUES (104, 'City centre get togheter', 'Come see the lively city centre and connect with new people.', '{"Latitude": 45.255030375342855, "Longitude": 19.845134261995558}', 25, 0, 0, 150, 5);  
    INSERT INTO encounters."Encounters"(
        "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range", "MiscEncounterTask")
        VALUES (105, 'Chill in the forest', 'Go for a nice relaxing walk, stop by for some hot coffe in Gorski Smesko and enjoy your day.', '{"Latitude": 45.18429791721585, "Longitude": 19.822502620518208}', 12, 0, 2, 500, 'Pet all the cats and dogs wandering around.');
    INSERT INTO encounters."Encounters"(
        "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range", "MiscEncounterTask")
        VALUES (106, 'Beach day', 'Enjoy the beach and have a great day.', '{"Latitude": 45.236198648134895, "Longitude": 19.848685506731275}', 12, 1, 2, 350, 'Go for a swim!');
   
