CREATE TABLE "Contact"
(
"ContactID" serial PRIMARY KEY,
"Nom" text NOT NULL,
"Prenom" text,
"Telephone" text,
"Service" text,
"DateEntree" DATE
);