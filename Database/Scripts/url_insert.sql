CREATE OR REPLACE FUNCTION url_insert(short_url varchar(50), long_url varchar(1000)) RETURNS VOID AS
$$
BEGIN
    INSERT INTO url (short_url, long_url, created_on) VALUES (short_url, long_url, CURRENT_DATE);
END
$$
  LANGUAGE 'plpgsql';