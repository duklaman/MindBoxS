SELECT art.subject, 
       ISNULL(tags.tagname , 'N/A')
FROM   articles art with (nolock)
       LEFT JOIN articletags artTags 
              ON art.id = artTags.articleid 
       LEFT JOIN tags tags 
              ON artTags.tagid = tags.id
ORDER BY art.subject, tags.tagname