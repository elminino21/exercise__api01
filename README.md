# Build an API

## Overview

We use Dapper extensively and regularly build out APIs for various stakeholders to consume the data we collect. In this exercise, please build a documented API using Clean Architecture or DDD principles which consumes the included `data.db` sqlite file.

## Requirements

- There are 3 required endpoints, but please feel free to add as many more as you want:
  1. `/api/applications` returns all applications in the Application table.
  1. `/api/applications/{id}` returns a single application.
  1. `/api/applications?category={categoryname}&date={daterange}` which filters by category and/or date range. **Date range must be inclusive** and **category should be case insensitive**.
- Use Dapper to query `data.db`.
- In essence, we're looking for a well architected API and expect that most edge cases are handled well.

## Submission

Once complete, reply to the original email that you recieved from us with the link to your Github repo.
