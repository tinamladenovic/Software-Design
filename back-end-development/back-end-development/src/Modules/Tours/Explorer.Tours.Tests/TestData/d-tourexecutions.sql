INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-1, -21, -125, '2023-11-09 15:00:25.421614+01', 0, 0, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -1, 'CompletionTime', null),
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -2, 'CompletionTime', null),
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -3, 'CompletionTime', null)
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-2, -22, -125, '2023-11-07 12:00:25.421614+01', 0, 0, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -1, 'CompletionTime', null),
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -2, 'CompletionTime', null),
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -3, 'CompletionTime', null)
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-3, -21, -125, '2023-11-07 12:00:25.421614+01', 0, 0, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -1, 'CompletionTime', null),
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -2, 'CompletionTime', null),
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -3, 'CompletionTime', null)
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-4, -21, -125, '2023-11-07 12:00:25.421614+01', 2, 0.0, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-5, -21, -125, '2023-11-07 12:00:25.421614+01', 2, 1.2, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', false, 'CheckpointId', -3, 'CompletionTime', null)
    ));

-- Completed tour executions for tourist 1 this month

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-6, -21, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-7, -21, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-8, -21, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-9, -21, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

-- Completed tour executions for tourist 2 this month

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-10, -22, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-11, -22, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 2.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-12, -22, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '2 hours', 1, 2.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

-- Completed tour executions for tourist 3 this month

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-13, -23, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-14, -23, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-15, -23, -125, date_trunc('month', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

-- Completed tour executions for tourist 1 this week

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-16, -21, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-17, -21, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-18, -21, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-19, -21, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

-- Completed tour executions for tourist 2 this week

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-20, -22, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-21, -22, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 2.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-22, -22, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 2.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

-- Completed tour executions for tourist 3 this week

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-23, -23, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-24, -23, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

INSERT INTO tours."TourExecutions"("Id", "TouristId", "TourId", "LastActivity", "Status", "CoveredDistance", "CheckpointStatuses")
VALUES 
    (-25, -23, -125, date_trunc('week', CURRENT_TIMESTAMP) + INTERVAL '12 hours', 1, 1.5, 
     jsonb_build_array(
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -1, 'CompletionTime', '2023-11-07 11:47:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -2, 'CompletionTime', '2023-11-07 11:55:25.421614+01'),
        jsonb_build_object('IsCompleted', true, 'CheckpointId', -3, 'CompletionTime', '2023-11-07 12:00:25.421614+01')
    ));

