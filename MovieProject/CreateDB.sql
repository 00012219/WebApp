set language english;
go

--insert sample directors
insert into Directors (BirthDate, Email, FirstName, LastName) values ('9/14/2005', 'eskehens0@soundcloud.com', 'Ennis', 'Skehens');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('8/29/2000', 'wseago1@google.co.uk', 'Wilburt', 'Seago');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('6/1/2009', 'jhryniewicki2@nsw.gov.au', 'Jade', 'Hryniewicki');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('6/24/2016', 'fparkinson3@howstuffworks.com', 'Frieda', 'Parkinson');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('7/4/2015', 'gcarlsen4@networksolutions.com', 'Giulio', 'Carlsen');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('12/14/2009', 'uashpole5@who.int', 'Ulrick', 'Ashpole');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('1/28/2005', 'llandon6@ft.com', 'Lucian', 'Landon');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('6/29/2011', 'lexrol7@globo.com', 'Loria', 'Exrol');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('8/15/2015', 'cgothard8@npr.org', 'Corinne', 'Gothard');
insert into Directors (BirthDate, Email, FirstName, LastName) values ('9/11/2016', 'erenihan9@netscape.com', 'Ella', 'Renihan');

--insert sample movies
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Vollidiot', 'Comedy|Drama', 1.1, '12/10/2017');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Westward Ho', 'Drama|Western', 4.7, '12/26/2009');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Achilles and the Tortoise (Akiresu to kame)', 'Comedy', 2.2, '6/15/2007');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Insignificance', 'Comedy|Drama', 3.3, '3/31/2021');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Werner - Das muss kesseln!!!', 'Animation|Comedy', 8.4, '6/16/2016');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('The Count of Monte Cristo', 'Action|Adventure|Drama|Romance|Thriller', 4.4, '7/4/2005');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Friend Among Strangers, Stranger Among Friends (Svoy sredi chuzhikh, chuzhoy sredi svoikh)', 'Action|War|Western', 5.2, '6/21/2003');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Gunfighter, The', 'Action|Western', 5.8, '3/3/2023');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Return from Witch Mountain', 'Children|Sci-Fi', 9.1, '12/1/2010');
insert into Movies (Title, Genre, Rating, ReleaseDate) values ('Three Colors: Blue (Trois couleurs: Bleu)', 'Drama', 5.3, '1/8/2003');


--assign the directors to the movies
insert into MovieDirectors(MovieId,DirectorId) values (1,1);
insert into MovieDirectors(MovieId,DirectorId) values (1,2);
insert into MovieDirectors(MovieId,DirectorId) values (1,3);
insert into MovieDirectors(MovieId,DirectorId) values (2,4);
insert into MovieDirectors(MovieId,DirectorId) values (2,5);
insert into MovieDirectors(MovieId,DirectorId) values (2,9);
insert into MovieDirectors(MovieId,DirectorId) values (3,2);
insert into MovieDirectors(MovieId,DirectorId) values (4,5);
insert into MovieDirectors(MovieId,DirectorId) values (4,6);
insert into MovieDirectors(MovieId,DirectorId) values (5,9);
insert into MovieDirectors(MovieId,DirectorId) values (6,10);
insert into MovieDirectors(MovieId,DirectorId) values (7,1);
insert into MovieDirectors(MovieId,DirectorId) values (8,2);
insert into MovieDirectors(MovieId,DirectorId) values (9,3);

