# How to handle real time streaming data in .NET MAUI Charts using suspend and resume notifications

Learn how to efficiently handle real-time streaming data in Syncfusion .NET MAUI Charts using SuspendSeriesNotification() and SuspendNotification(). This guide demonstrates chart-level and series-level update techniques that help reduce unnecessary rendering, improve performance, and provide a smoother visual experience when displaying continuously updating data.

## What this sample includes

- Creating a .NET MAUI Cartesian Chart for real-time data visualization
- Loading initial data before streaming begins
- Updating multiple series using SuspendSeriesNotification()
- Updating a single series using SuspendNotification()
- Streaming live data using a DispatcherTimer
- Improving chart rendering performance during frequent updates
- Demonstrating both chart-level and series-level notification management

## How it works

- The chart is configured with one or more data series bound to observable data collections.
- Initial data points are added to populate the chart before live streaming starts.
- For multiple series updates, SuspendSeriesNotification() temporarily pauses chart refresh notifications while all series are updated.
- After the updates are completed, ResumeSeriesNotification() triggers a single chart refresh, reducing rendering overhead.
- For single series updates, SuspendNotification() pauses notifications only for the targeted series during data updates.
- ResumeNotification() re-enables notifications and refreshes the series after the new data point is added.
- A DispatcherTimer continuously generates and streams new data points to simulate real-time data updates.

## Requirements

- .NET MAUI
- Syncfusion .NET MAUI Charts
- Syncfusion SfCartesianChart control
- Visual Studio 2022 or later
- .NET 8.0 or later

## Output

This sample demonstrates how to efficiently stream live data in .NET MAUI Charts using chart-level and series-level suspend and resume notifications for optimal real-time rendering performance.

## Troubleshooting

### Path Too Long Exception

If you are facing a "Path too long" exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

For a detailed step-by-step guide with relevant code snippets, refer to the How to handle real-time streaming data in .NET MAUI Charts using suspend and resume notifications article.