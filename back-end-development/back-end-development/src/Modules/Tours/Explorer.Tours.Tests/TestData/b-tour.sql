INSERT INTO tours."Tours"(
	"Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
	VALUES (-123, -11, 'Planinarska tura', 'Planinarska tura', 0, 
			'[
			  {{ "TravelTime": 30, "TravelMethod": 0 }},
			  {{ "TravelTime": 60, "TravelMethod": 1 }},
			  {{ "TravelTime": 15, "TravelMethod": 2 }}
			]', 0, 0, 'planina,reka,suma', 100, NULL, NULL);

INSERT INTO tours."Tours"(
	"Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
	VALUES (-124, -12, 'Planinarska tura', 'Planinarska tura', 0, 
			'[
			  {{ "TravelTime": 30, "TravelMethod": 0 }},
			  {{ "TravelTime": 60, "TravelMethod": 1 }},
			  {{ "TravelTime": 15, "TravelMethod": 2 }}
			]', 1, 200, 'planina,reka,suma', 100, '2023-11-09 15:00:25.421614+01', NULL);

INSERT INTO tours."Tours"(
	"Id", "AuthorId", "Name", "Description", "Difficult", "TravelTimeAndMethod", "Status", "Price", "Tags", "Distance", "PublishTime", "ArchiveTime")
	VALUES (-125, -12, 'Planinarska tura', 'Planinarska tura', 0, 
			'[
			  {{ "TravelTime": 30, "TravelMethod": 0 }},
			  {{ "TravelTime": 60, "TravelMethod": 1 }},
			  {{ "TravelTime": 15, "TravelMethod": 2 }}
			]', 1, 20, 'planina,reka,suma', 100, '2023-11-09 15:00:25.421614+01', NULL);

