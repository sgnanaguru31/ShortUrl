CREATE TABLE Url (
	id serial PRIMARY KEY,
	short_url VARCHAR ( 50 ) NOT NULL,
	long_url VARCHAR ( 1000 ) NOT NULL,
	created_on DATE NOT NULL
);

CREATE INDEX index_short_url
ON url (short_url);