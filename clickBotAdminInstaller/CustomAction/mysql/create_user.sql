CREATE USER 'biralman'@'localhost' IDENTIFIED BY 'biralman!@#';
GRANT USAGE ON *.* TO 'biralman'@'localhost' IDENTIFIED BY 'biralman!@#';
GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE ON `biralDB`.* TO 'biralman'@'localhost';
GRANT all ON `biralDB`.* TO 'biralman'@'localhost';

CREATE USER 'biralman'@'%' IDENTIFIED BY 'biralman!@#';
GRANT USAGE ON *.* TO 'biralman'@'%' IDENTIFIED BY 'biralman!@#';
GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE ON `biralDB`.* TO 'biralman'@'%';
GRANT all ON `biralDB`.* TO 'biralman'@'%';
