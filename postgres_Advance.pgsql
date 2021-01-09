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
INSERT into match Values
(5,'01/08/2020',1000,9,'Chelsea','Everton')

insert into result values(5,1,2);

alter table team_result drop column point;


