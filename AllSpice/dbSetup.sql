-- Active: 1666715464348@@SG-shaded-voice-9071-6836-mysql-master.servers.mongodirector.com@3306@Classroom

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(255),
        img VARCHAR(255) NOT NULL,
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(255) NOT NULL,
        quantity VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        Foreign Key (recipeId) REFERENCES recipes(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS favorites(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        Foreign Key (accountId) REFERENCES accounts(id),
        Foreign Key (recipeId) REFERENCES recipes(id)
    ) default charset utf8 COMMENT '';

SELECT r.*, a.*
FROM recipes r
    JOIN accounts a ON a.id = r.creatorId;

DROP TABLE ingredients;