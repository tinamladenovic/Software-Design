-- Encounter 1 Social
INSERT INTO encounters."Encounters"(
    "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range")
VALUES (-1, 'Forest Ambush', 'A surprise attack by bandits in the dense forest', jsonb_build_object('Latitude', 35.1234, 'Longitude', -85.5678), 5, 1, 0, 50);

-- Encounter 2 Hidden Location
INSERT INTO encounters."Encounters"(
    "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range", "ImageUrl")
VALUES (-2, 'Mysterious Cave', 'Explore a mysterious cave filled with glowing crystals', jsonb_build_object('Latitude', 40.6789, 'Longitude', -75.4321), 8, 0, 1, 50, 'slika.png');

-- Encounter 3 Misc
INSERT INTO encounters."Encounters"(
    "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range")
VALUES (-3, 'Haunted Ruins', 'Investigate ancient ruins haunted by spectral entities', jsonb_build_object('Latitude', 38.9876, 'Longitude', -92.3456), 3, 2, 2, 50);

-- Encounter 4 Hidden Location
INSERT INTO encounters."Encounters"(
    "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range")
VALUES (-4, 'Mountain Expedition', 'Scale the treacherous peaks to uncover hidden treasures', jsonb_build_object('Latitude', 40.6789, 'Longitude', -75.4321), 10, 1, 1, 50);

-- Encounter 5 Misc
INSERT INTO encounters."Encounters"(
    "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range")
VALUES (-5, 'Underwater Exploration', 'Dive into the depths to uncover lost underwater city secrets', jsonb_build_object('Latitude', -25.6789, 'Longitude', 153.9876), 6, 0, 2, 50);

-- Encounter 6 Hidden Location
INSERT INTO encounters."Encounters"(
    "Id", "Name", "Description", "Coordinates", "Xp", "Status", "Type", "Range", "ImageUrl")
VALUES (-6, 'Mysterious Cave', 'Explore a mysterious cave filled with glowing crystals', jsonb_build_object('Latitude', 40.6789, 'Longitude', -75.4321), 8, 0, 1, 50, 'slika.png');
