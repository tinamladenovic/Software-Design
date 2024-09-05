INSERT INTO payments."TourBundle"(
	"Id", "AuthorId", "Name", "Price", "Status", "Tours")
	VALUES (-111, -12, 'Bundle1', 199.99, 1, 
	'[
		{{ "Status": 1, "TourId": -124, "TourName": "Pustinjska tura"}},
		{{ "Status": 1, "TourId": -125, "TourName": "neka druga tura"}}
	]');

INSERT INTO payments."TourBundle"(
	"Id", "AuthorId", "Name", "Price", "Status", "Tours")
	VALUES (-112, -12, 'Bundle1', 99.99, 0, 
	'[
		{{ "Status": 1, "TourId": -124, "TourName": "Pustinjska tura"}},
		{{ "Status": 1, "TourId": -125, "TourName": "neka druga tura"}}
	]');