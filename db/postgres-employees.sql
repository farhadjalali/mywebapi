CREATE DATABASE employees;
\c employees;

DROP TABLE IF EXISTS persons;

CREATE TABLE persons (
    id SERIAL PRIMARY KEY,
    birth_date  DATE            NOT NULL,
    first_name  VARCHAR(14)     NOT NULL,
    last_name   VARCHAR(16)     NOT NULL
);

INSERT INTO persons (birth_date, first_name, last_name) VALUES
    ('1972-05-13','Peter','Diaz'),
    ('1987-09-25','Leon','Leonard'),
    ('1974-05-10','Shirley','Baker'),
    ('1986-08-17','David','Allen'),
    ('1959-10-14','Nancy','Davis'),
    ('1964-07-05','Michael','Wray'),
    ('1980-10-08','Wanda','Inniss');