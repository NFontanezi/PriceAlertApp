# PriceAlertApp

PriceAlertApp is a console application used to monitor stock prices in the financial market. Price parameters determine the price limits, and alerts are sent if any of the limits are reached. The app refreshes every 5 minutes while it is open.

## Instructions to Run

1. **Configure the AppSettings.json**:
   - Adjust the `AppSettings.json` file to configure email alerts.

2. **Open CMD in the Executable Folder**:
   - Navigate to the folder where the `PriceAlertApp.Console.exe` executable is located.

3. **Run the Application with Parameters**:
   - Execute the application using the following parameter pattern:
     ```
     PriceAlertApp.Console.exe RunPriceAlert_{stock}_{minPrice}_{maxPrice}
     ```

## Parameter Patterns

- `stock`: Stock name + ".suffix"
  - For B3 stocks, suffixes are not mandatory.
  - For other exchanges, suffixes are mandatory.
- `minPrice/maxPrice`: separed by ".".

### Examples

1. **B3 Stock without Suffix**:
   ```
   PriceAlertApp.Console.exe RunPriceAlert_PETR4_2.34_35.02
   or
   PriceAlertApp.Console.exe RunPriceAlert_PETR4.SA_2.34_35.02
    ```
   
   



