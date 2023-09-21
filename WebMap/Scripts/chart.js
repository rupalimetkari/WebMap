document.addEventListener('DOMContentLoaded', function () {

    Highcharts.chart('highchartcontainer', {
        chart: {
            type: 'spline'
        },
        title: {
            text: 'Price Comparison'
        },
        xAxis: {
            categories: siteNames,
            labels: {
                rotation: -45
            },
            min: 0, 
            max: 10, 
            scrollbar: {
                enabled: true
            }
        },
        yAxis: {
            title: {
                text: 'Price'
            }
        },
        tooltip: {
            crosshairs: true,
            shared: true
        },
        plotOptions: {
            spline: {
                marker: {
                    radius: 4,
                    lineColor: '#666666',
                    lineWidth: 1
                }
            }
        },
        series: [{
            name: 'Client Median Price',
            data: clusterMedianPrices,
            marker: {
                symbol: 'square'
            }
        }, {
            name: 'Client Market Price',
            data: clientMarketPrices,
            marker: {
                symbol: 'diamond'
            }
        }]
    }); 
});