using System;
using System.Collections.Generic;
using Traffic.Enums;

namespace Traffic.Tools
{
    internal static class Calculations
    {
        public static uint CalcCarsInTraffic(uint numberOfCars, uint numberOfMotorcycles, uint numberOfTrucks, uint numberOfRoadTrains)
        {
            uint numberOfVehicles = numberOfCars + numberOfMotorcycles + numberOfTrucks + numberOfRoadTrains;

            if (numberOfVehicles <= 0) throw new Exception("Количество автомобилей должно быть больше 0.");
            else return (uint)Math.Truncate(((double)numberOfCars) / numberOfVehicles * 100);
        }

        public static uint CalcTrafficIntensity(uint numberOfCars, uint numberOfMotorcycles, uint numberOfTrucks, uint numberOfRoadTrains)
        {
            uint numberOfVehicles = numberOfCars + numberOfMotorcycles + numberOfTrucks + numberOfRoadTrains;

            if (numberOfVehicles <= 0) throw new Exception("Количество автомобилей должно быть больше 0.");
            else return (uint)Math.Truncate(1.0 * numberOfCars + 0.5 * numberOfMotorcycles + 2.5 * numberOfTrucks + 4.5 * numberOfRoadTrains);
        }

        public static uint CalcMaxTheoreticalBandwidth(
            uint numberOfCars,
            uint numberOfMotorcycles,
            uint numberOfTrucks,
            uint numberOfRoadTrains,
            uint maxAllowedSpeed,
            uint slope,
            RoadConditionEnum roadCondition,
            NumberOfLanesEnum numberOfLanes
        )
        {
            double getC()
            {
                double c = 1;

                if (slope < 20)
                {
                    c = 1.0;
                }
                else if (slope >= 20 && slope < 30)
                {
                    c = 0.92;
                }
                else if (slope >= 30 && slope < 40)
                {
                    c = 0.84;
                }
                else if (slope >= 40 && slope < 50)
                {
                    c = 0.76;
                }
                else if (slope >= 50 && slope < 70)
                {
                    c = 0.68;
                }
                else if (slope >= 70 && slope < 80)
                {
                    c = 0.45;
                }
                else if (slope >= 80)
                {
                    c = 0.34;
                }

                return c;
            }
            Dictionary<RoadConditionEnum, double> fValues = new Dictionary<RoadConditionEnum, double>()
            {
                [RoadConditionEnum.AsphaltExcellent] = 0.018,
                [RoadConditionEnum.AsphaltSatisfactory] = 0.020,
                [RoadConditionEnum.AsphaltAfterRain] = 0.03,
                [RoadConditionEnum.Gravel] = 0.025,
                [RoadConditionEnum.DirtDry] = 0.035,
                [RoadConditionEnum.DirtAfterRain] = 0.1,
                [RoadConditionEnum.Snow] = 0.03,
                [RoadConditionEnum.Ice] = 0.02
            };
            Dictionary<NumberOfLanesEnum, double> kValues = new Dictionary<NumberOfLanesEnum, double>()
            {
                [NumberOfLanesEnum.One] = 1,
                [NumberOfLanesEnum.Two] = 1.9,
                [NumberOfLanesEnum.Three] = 2.7,
                [NumberOfLanesEnum.Four] = 3.5
            };

            uint numberOfVehicles = numberOfCars + numberOfMotorcycles + numberOfTrucks + numberOfRoadTrains;
            if (numberOfVehicles <= 0)
            {
                throw new Exception("Количество автомобилей должно быть больше 0.");
            }
            else
            {
                double averageVehicleLength = Math.Truncate((numberOfCars * 5 + numberOfMotorcycles * 2 + numberOfTrucks * 8 + numberOfRoadTrains * 15) / ((double)numberOfVehicles));
                double c = getC();
                double f = fValues[roadCondition];
                double k = kValues[numberOfLanes];
                double v = (maxAllowedSpeed / 3.6) + (maxAllowedSpeed * maxAllowedSpeed * 1.2 / (254 * (0.5 + c + f))) + averageVehicleLength + 5;
                return (uint)Math.Truncate(1000 * maxAllowedSpeed / v * k);
            }
        }

        public static uint CalcMaxPracticalBandwidth(
            NumberOfLanesEnum numberOfLanesOnStart,
            NumberOfLanesEnum numberOfLanesOnEnd,
            uint maxAllowedSpeed,
            RoadConditionEnum roadCondition
        )
        {
            double GetF()
            {
                double f_ret = 0;

                switch ((int)roadCondition)
                {
                    case 0: f_ret = 0.018; break;
                    case 1: f_ret = 0.020; break;
                    case 3: f_ret = 0.025; break;
                    case 4: f_ret = 0.035; break;
                    case 5: f_ret = 0.1; break;
                    case 6: f_ret = 0.03; break;
                    case 7: f_ret = 0.02; break;
                    case 2: f_ret = 0.03; break;
                }

                return f_ret;
            }

            uint z = maxAllowedSpeed;
            double f = GetF();

            double j = 0, v, d, k = 0;
            int stripesStart = (int)numberOfLanesOnStart;
            int stripesEnd = (int)numberOfLanesOnEnd;

            if (stripesStart == stripesEnd)
            {
                if (stripesStart == 0 || stripesEnd == 0)
                {
                    j = 1.0;
                }
                else if (stripesStart == 1 || stripesEnd == 1)
                {
                    j = 1.9;
                }
                else if (stripesStart == 2 || stripesEnd == 2)
                {
                    j = 2.7;
                }
                else if (stripesStart == 3 || stripesEnd == 3)
                {
                    j = 3.5;
                }

                v = (z / 3.6) + (z * z * 1.2 / (254 * (0.5 + 1.0 + f))) + 5 + 5;
                d = Math.Truncate(1000 * z / v * j * 2);
            }
            else
            {
                if (stripesStart == 0 && stripesEnd == 1)
                {
                    j = 1.0;
                    k = 1.9;
                }
                else if (stripesStart == 0 && stripesEnd == 2)
                {
                    j = 1.0;
                    k = 2.7;
                }
                else if (stripesStart == 0 && stripesEnd == 3)
                {
                    j = 1.0;
                    k = 3.5;
                }
                else if (stripesStart == 1 && stripesEnd == 0)
                {
                    j = 1.9;
                    k = 1.0;
                }
                else if (stripesStart == 1 && stripesEnd == 2)
                {
                    j = 1.9;
                    k = 2.7;
                }
                else if (stripesStart == 1 && stripesEnd == 3)
                {
                    j = 1.9;
                    k = 3.5;
                }
                else if (stripesStart == 2 && stripesEnd == 0)
                {
                    j = 2.7;
                    k = 1.0;
                }
                else if (stripesStart == 2 && stripesEnd == 1)
                {
                    j = 2.7;
                    k = 1.9;
                }
                else if (stripesStart == 2 && stripesEnd == 3)
                {
                    j = 2.7;
                    k = 3.5;
                }
                else if (stripesStart == 3 && stripesEnd == 0)
                {
                    j = 3.5;
                    k = 1.0;
                }
                else if (stripesStart == 3 && stripesEnd == 1)
                {
                    j = 3.5;
                    k = 1.9;
                }
                else if (stripesStart == 3 && stripesEnd == 2)
                {
                    j = 3.5;
                    k = 2.7;
                }

                double v3 = (z / 3.6) + ((z * z * 1.2) / (254 * (0.5 + 1.0 + f))) + 5 + 5;
                double v4 = (z / 3.6) + ((z * z * 1.2) / (254 * (0.5 + 1.0 + f))) + 5 + 5;
                double v1 = Math.Truncate((((1000 * z) / v3) * j));
                double v2 = Math.Truncate((((1000 * z) / v4) * k));
                d = Math.Truncate(v1 + v2);
            }

            return (uint)d;
        }

        public static uint CalcTrafficIntensity(
            NumberOfLanesEnum numberOfLanesOnStart,
            NumberOfLanesEnum numberOfLanesOnEnd
        )
        {
            int stripesStart = (int)numberOfLanesOnStart;
            int stripesEnd = (int)numberOfLanesOnEnd;

            uint GetC()
            {
                if (stripesStart == 0 && stripesEnd == 0)
                {
                    return 1300;
                }

                if (stripesStart == 1 && stripesEnd == 1)
                {
                    return 2300;
                }

                if (stripesStart == 2 && stripesEnd == 2)
                {
                    return 3500;
                }

                if (stripesStart == 3 && stripesEnd == 3)
                {
                    return 4600;
                }

                if (stripesStart == 0 && stripesEnd == 1 || stripesStart == 1 && stripesEnd == 0)
                {
                    return 1800;
                }

                if (stripesStart == 0 && stripesEnd == 2 || stripesStart == 2 && stripesEnd == 0)
                {
                    return 2400;
                }

                if (stripesStart == 0 && stripesEnd == 3 || stripesStart == 3 && stripesEnd == 0)
                {
                    return 2950;
                }

                if (stripesStart == 1 && stripesEnd == 2 || stripesStart == 1 && stripesEnd == 2)
                {
                    return 2900;
                }

                if (stripesStart == 1 && stripesEnd == 3 || stripesStart == 1 && stripesEnd == 3)
                {
                    return 3450;
                }

                if (stripesStart == 2 && stripesEnd == 3 || stripesStart == 2 && stripesEnd == 3)
                {
                    return 4050;
                }

                return 0; // throw exception
            }

            uint c = GetC();
            return c;
        }

        public static uint CalcRoadCongestion(
            uint trafficIntensity,
            uint maxPracticalBandwidth
        )
        {
            uint c = trafficIntensity;
            double a = maxPracticalBandwidth;
            double b = Math.Truncate(c / a * 100);
            return (uint)b;
        }
    }
}