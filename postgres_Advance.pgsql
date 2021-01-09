---create trigger auto update to team_result when has result match
create or replace FUNCTION tg_insert_into_teamresult1 () RETURNS
TRIGGER as
$$
DECLARE
match_result match_result_view%ROWTYPE;

BEGIN
 select into match_result * from match_result_view where match_id=NEW.match_id;

    if match_result.home_res > match_result.away_res then
        UPDATE team_result set win_match=win_match+1,
                                goal_for=goal_for+match_result.home_res,
                                goal_againt=goal_againt+match_result.away_res
                         where team_name=match_result.hometeam_name;
        UPDATE team_result set lose_match=lose_match+1 ,
                                goal_for=goal_for+match_result.away_res,
                                goal_againt=goal_againt+match_result.home_res
                            where team_name=match_result.awayteam_name;
                 return new;
    elseif match_result.home_res < match_result.away_res THEN
        UPDATE team_result set lose_match=lose_match+1 ,
                                goal_for=goal_for+match_result.home_res,
                                goal_againt=goal_againt+match_result.away_res
                         where team_name=match_result.hometeam_name;
        UPDATE team_result set win_match=win_match+1,
                                goal_for=goal_for+match_result.away_res,
                                goal_againt=goal_againt+match_result.home_res
        
            where team_name=match_result.awayteam_name;
        return new;
    else 
         UPDATE team_result set draw_match=draw_match+1, 
                                 goal_for=goal_for+match_result.home_res,
                                goal_againt=goal_againt+match_result.away_res
         
                             where team_name=match_result.hometeam_name;
            UPDATE team_result set draw_match=draw_match+1,
                                     goal_for=goal_for+match_result.home_res,
                                goal_againt=goal_againt+match_result.away_res
            where team_name=match_result.awayteam_name;
      return new;
      end if;      

END;
$$ LANGUAGE plpgsql;



create trigger after_insert_result
after insert on result
for each row
EXECUTE PROCEDURe tg_insert_into_teamresult1();
----
----
----create a view for position's league


create view rank_table as
create view rank_table as
select *,(win_match*3+draw_match)as point ,(win_match+lose_match+draw_match) as played
from team_result order by point desc;


----test

-----
---create view for match detail----
create view match_info_dto as
SELECT 
    m1.stadium_id,
    m1.match_id,
    m1.datetime,
    m1.attendance,
    m1.hometeam_name,
    m1.awayteam_name,
    r.home_res,
    r.away_res,
    s.stadium_name,
    s.city,
    s.capacity,
    ( SELECT t.team_image AS home_image
           FROM team t,
            match m
          WHERE t.team_name = m.hometeam_name AND m.match_id= m1.match_id) AS home_image,
  
    ( SELECT t.team_image 
           FROM team t,
            match m
          WHERE t.team_name = m.awayteam_name AND m.match_id = m1.match_id) AS away_image
   FROM match m1
     JOIN result r USING (match_id)
     JOIN stadium s USING (stadium_id);
--------

