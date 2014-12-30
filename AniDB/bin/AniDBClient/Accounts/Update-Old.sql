ALTER TABLE mylist_local ADD COLUMN mylist_local_sum MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sumW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sumpercent MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sumSize MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sumSizeW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sumpercentsize MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sumL MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_countsum MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sizesum MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_lensum MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_watchedsum MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_watchedunknownpercent MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_watchedhddpercent MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_watchedcdpercent MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_watcheddeletedpercent MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_musicW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_music MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_musicpercent MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_musicSizeW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_musicSize MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_musicpercentsize MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_musicL MEMO
UPDATE mylist_local SET mylist_local_tvL = '0s'
UPDATE mylist_local SET mylist_local_tvsL = '0s'
UPDATE mylist_local SET mylist_local_moviesL = '0s'
UPDATE mylist_local SET mylist_local_ovaL = '0s'
UPDATE mylist_local SET mylist_local_webL = '0s'
UPDATE mylist_local SET mylist_local_othersL = '0s'
UPDATE mylist_local SET mylist_local_unknownL = '0s'
UPDATE mylist_local SET mylist_local_sumL = '0s'
UPDATE mylist_local SET mylist_local_musicL = '0s'
CREATE TABLE mylist_storages
ALTER TABLE mylist_storages ADD COLUMN id_mylist_storages COUNTER PRIMARY KEY
ALTER TABLE mylist_storages ADD COLUMN mylist_storages_storage MEMO
ALTER TABLE mylist_storages ADD COLUMN mylist_storages_count MEMO
ALTER TABLE mylist_storages ADD COLUMN mylist_storages_percent MEMO
CREATE TABLE mylist_sources
ALTER TABLE mylist_sources ADD COLUMN id_mylist_sources COUNTER PRIMARY KEY
ALTER TABLE mylist_sources ADD COLUMN mylist_sources_source MEMO
ALTER TABLE mylist_sources ADD COLUMN mylist_sources_count MEMO
ALTER TABLE mylist_sources ADD COLUMN mylist_sources_percent MEMO
ALTER TABLE mylist_storages ADD COLUMN mylist_storages_size MEMO
ALTER TABLE mylist_sources ADD COLUMN mylist_sources_size MEMO
UPDATE files SET files_date = '2/2/2009' WHERE ((Len([files].[files_date] & '')=0))
UPDATE files SET files_date = '2.2.2009' WHERE ((Len([files].[files_date] & '')=0))
UPDATE files SET files_date = '#2/2/2009#' WHERE ((Len([files].[files_date] & '')=0))
UPDATE files SET files_date = '#2.2.2009#' WHERE ((Len([files].[files_date] & '')=0))
CREATE TABLE hash_files
ALTER TABLE hash_files ADD COLUMN id_hash_files COUNTER PRIMARY KEY
ALTER TABLE hash_files ADD COLUMN hash_files_file MEMO
ALTER TABLE files ADD COLUMN files_extension MEMO
ALTER TABLE files ADD COLUMN files_biterate_video INTEGER
ALTER TABLE files ADD COLUMN files_biterate_audio INTEGER
ALTER TABLE files ADD COLUMN files_anidb_name MEMO
ALTER TABLE files ADD COLUMN files_date_air DATE
CREATE TABLE anime_relations
ALTER TABLE anime_relations ADD COLUMN id_anime_relations COUNTER PRIMARY KEY
ALTER TABLE anime_relations ADD COLUMN id_anime INTEGER
ALTER TABLE anime_relations ADD COLUMN id_relation INTEGER
ALTER TABLE anime_relations ADD COLUMN id_anime_related INTEGER
ALTER TABLE anime ADD COLUMN anime_epn_spec INTEGER
ALTER TABLE anime ADD COLUMN anime_date_air DATE
ALTER TABLE anime ADD COLUMN anime_date_end DATE
ALTER TABLE anime ADD COLUMN anime_url MEMO
ALTER TABLE anime ADD COLUMN anime_18 INTEGER
ALTER TABLE mylist_local ADD COLUMN mylist_local_tvLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_tvsLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_moviesLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_ovaLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_webLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_othersLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_unknownLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sumLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_tvLP MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_tvsLP MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_moviesLP MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_ovaLP MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_webLP MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_othersLP MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_unknownLP MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_sumLP MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_musicLW MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_musicLP MEMO
UPDATE mylist_local SET mylist_local_tvLW='0s'
UPDATE mylist_local SET mylist_local_tvsLW='0s'
UPDATE mylist_local SET mylist_local_moviesLW='0s'
UPDATE mylist_local SET mylist_local_ovaLW='0s'
UPDATE mylist_local SET mylist_local_webLW='0s'
UPDATE mylist_local SET mylist_local_othersLW='0s'
UPDATE mylist_local SET mylist_local_unknownLW='0s'
UPDATE mylist_local SET mylist_local_sumLW='0s'
UPDATE mylist_local SET mylist_local_tvLP='0%'
UPDATE mylist_local SET mylist_local_tvsLP='0%'
UPDATE mylist_local SET mylist_local_moviesLP='0%'
UPDATE mylist_local SET mylist_local_ovaLP='0%'
UPDATE mylist_local SET mylist_local_webLP='0%'
UPDATE mylist_local SET mylist_local_othersLP='0%'
UPDATE mylist_local SET mylist_local_unknownLP='0%'
UPDATE mylist_local SET mylist_local_sumLP='0%'
UPDATE mylist_local SET mylist_local_musicLW='0s'
UPDATE mylist_local SET mylist_local_musicLP='0%'
ALTER TABLE mylist_local ADD COLUMN mylist_local_18 MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_18P MEMO
UPDATE mylist_local SET mylist_local_18='0'
UPDATE mylist_local SET mylist_local_18P='0%'
ALTER TABLE anime ALTER COLUMN anime_url MEMO
CREATE TABLE watcher
ALTER TABLE watcher ADD COLUMN id_watcher COUNTER PRIMARY KEY
ALTER TABLE watcher ADD COLUMN watcher_path MEMO
CREATE TABLE manga
CREATE TABLE manga_chapters
CREATE TABLE manga_anime
CREATE TABLE manga_genres
CREATE TABLE mylist_manga
ALTER TABLE manga ADD COLUMN id_manga COUNTER PRIMARY KEY
ALTER TABLE manga ADD COLUMN manga_nazevjap MEMO
ALTER TABLE manga ADD COLUMN manga_nazevkaj MEMO
ALTER TABLE manga ADD COLUMN manga_nazeveng MEMO
ALTER TABLE manga ADD COLUMN manga_rok MEMO
ALTER TABLE manga ADD COLUMN manga_obr MEMO
ALTER TABLE manga ADD COLUMN manga_18 INTEGER
ALTER TABLE manga ADD COLUMN manga_MU INTEGER
ALTER TABLE manga ADD COLUMN manga_MT INTEGER
ALTER TABLE manga ADD COLUMN manga_volume INTEGER
ALTER TABLE manga ADD COLUMN manga_artist MEMO
ALTER TABLE manga ADD COLUMN manga_author MEMO
ALTER TABLE manga_chapters ADD COLUMN id_manga_chatpers COUNTER PRIMARY KEY
ALTER TABLE manga_chapters ADD COLUMN id_manga INTEGER
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_chatper INTEGER
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_volume INTEGER
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_size INTEGER
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_date DATE
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_now DATE
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_read INTEGER
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_pages INTEGER
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_lang MEMO
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_file MEMO
ALTER TABLE manga_chapters ADD COLUMN manga_chatpers_name MEMO
ALTER TABLE manga_anime ADD COLUMN id_manga_anime COUNTER PRIMARY KEY
ALTER TABLE manga_anime ADD COLUMN id_anime INTEGER
ALTER TABLE manga_anime ADD COLUMN id_manga INTEGER
ALTER TABLE manga_genres ADD COLUMN id_manga_genres COUNTER PRIMARY KEY
ALTER TABLE manga_genres ADD COLUMN id_genres INTEGER
ALTER TABLE manga_genres ADD COLUMN id_manga INTEGER
ALTER TABLE mylist_manga ADD COLUMN id_mylist_manga COUNTER PRIMARY KEY
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_manga MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_volumes MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_chapters MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_size_files MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_manga_read MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_manga_readP MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_pages MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_manga_18 MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_manga_18P MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_pages_read MEMO
ALTER TABLE mylist_manga ADD COLUMN mylist_manga_pages_readP MEMO
INSERT INTO mylist_manga VALUES (1, '0', '0', '0', '0 MB', '0', '0%', '0', '0', '0%',  '0', '0%')
ALTER TABLE anime ADD COLUMN anime_length MEMO
ALTER TABLE anime ADD COLUMN anime_watched INTEGER
CREATE TABLE tags
CREATE TABLE tags_relation
ALTER TABLE tags ADD COLUMN id_tags COUNTER PRIMARY KEY
ALTER TABLE tags ADD COLUMN tags_name MEMO
ALTER TABLE tags_relation ADD COLUMN id_tags_relation COUNTER PRIMARY KEY
ALTER TABLE tags_relation ADD COLUMN id_tags INTEGER
ALTER TABLE tags_relation ADD COLUMN id_anime INTEGER
ALTER TABLE anime ADD COLUMN anime_rating INTEGER
ALTER TABLE anime ADD COLUMN anime_seen DATE
UPDATE anime SET anime_rating = 0 WHERE ((Len([anime].[anime_rating] & '')=0))
UPDATE anime SET anime_seen = '1.1.2000' WHERE ((Len([anime].[anime_seen] & '')=0))
ALTER TABLE mylist_anidb ADD COLUMN mylist_anidb_mylistviewedmin MEMO
UPDATE mylist_anidb SET  mylist_anidb_mylistviewedmin = "0"
CREATE TABLE manga_relations
ALTER TABLE manga_relations ADD COLUMN id_manga_relations COUNTER INTEGER
ALTER TABLE manga_relations ADD COLUMN id_manga INTEGER
ALTER TABLE manga_relations ADD COLUMN id_manga_related INTEGER
ALTER TABLE manga_chapters DROP COLUMN manga_chatpers_date
ALTER TABLE manga_chapters DROP COLUMN manga_chatpers_now
ALTER TABLE manga ADD COLUMN manga_url MEMO
ALTER TABLE mylist_local ADD COLUMN mylist_local_update MEMO
UPDATE mylist_local SET mylist_local_update = "1*1"
UPDATE mylist_local SET mylist_local_update = '1*1'
ALTER TABLE manga ADD COLUMN manga_MAL INTEGER
ALTER TABLE manga ADD COLUMN manga_MugiMugi INTEGER
UPDATE manga SET manga_MAL=0 WHERE ((Len([manga].[manga_MAL] & '')=0))
UPDATE manga SET manga_MugiMugi=0 WHERE ((Len([manga].[manga_MugiMugi] & '')=0))
ALTER TABLE hash_files ADD COLUMN hash_files_size MEMO
UPDATE hash_files SET hash_files_size='0' WHERE ((Len([hash_files].[hash_files_size] & '')=0))
ALTER TABLE files ADD COLUMN files_depth MEMO