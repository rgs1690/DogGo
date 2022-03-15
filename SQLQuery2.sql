SELECT o.Id, o.[Name], Phone, n.[Name], Address, Email
FROM Owner o
LEFT JOIN Neighborhood n ON n.Id = o.NeighborhoodId;  