ALTER TABLE "Competidores" ALTER COLUMN "Sexo" TYPE char;
UPDATE "Competidores" SET "Sexo" = 'M' where "Sexo" = '1';
UPDATE "Competidores" SET "Sexo" = 'F' where "Sexo" = '2';
UPDATE "Competidores" SET "Sexo" = 'O' where "Sexo" = '3';