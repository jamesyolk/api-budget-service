# api-budget-service

## POST: /api/v1/budget

This endpoint accepts a startDate, and numberOfDays to calculate total budget
of buying one banana in each of those days (excluding Saturday and Sunday). The cost 
of bananas are split into tiers. First seven days of the month is the starting tier at $0.05 per banana, and increases by $0.05 each subsequent tier/7-days.

## Curl
curl -X POST \
  https://api-budget-service.azurewebsites.net/api/v1/budgets \
  -H 'Content-Type: application/json' \
  -d '{
    "startDate": "03/09/2019",
    "numberOfDays": 25
}'

## Example Request
{
    "startDate": "03/09/2019",
    "numberOfDays": 25
}

## Example Response
{
    "budget": 2.5
}

## Web Test
Test out this endpoint by going to https://api-budget-service.azurewebsites.net/index.html

- Expand the endpoint and click "Try it out" on upper right side
- Modify request body, and enter "1" for version
- Click the blue "Execute" below to send the request
