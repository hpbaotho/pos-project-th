DECLARE @PeriodGroupIDMonthly BIGINT, @PeriodGroupIDDaily BIGINT, @PeriodGroupIDWeekly BIGINT

SELECT @PeriodGroupIDMonthly = period_group_id FROM in_period_group WHERE period_group_code = '2'
SELECT @PeriodGroupIDDaily = period_group_id FROM in_period_group WHERE period_group_code = '3'
SELECT @PeriodGroupIDWeekly = period_group_id FROM in_period_group WHERE period_group_code = '4'

INSERT INTO in_period VALUES(@PeriodGroupIDMonthly,'M1','2015-02-01',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDMonthly,'M2','2015-03-01',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDMonthly,'M3','2015-04-01',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDMonthly,'M4','2015-05-01',1,NULL,NULL,NULL,NULL,'O')

INSERT INTO in_period VALUES(@PeriodGroupIDDaily,'D1','2015-02-01',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDDaily,'D2','2015-02-02',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDDaily,'D3','2015-02-03',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDDaily,'D4','2015-02-04',1,NULL,NULL,NULL,NULL,'O')

INSERT INTO in_period VALUES(@PeriodGroupIDDaily,'D1','2015-02-01',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDDaily,'D2','2015-02-07',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDDaily,'D3','2015-02-14',1,NULL,NULL,NULL,NULL,'O')
INSERT INTO in_period VALUES(@PeriodGroupIDDaily,'D4','2015-02-22',1,NULL,NULL,NULL,NULL,'O')