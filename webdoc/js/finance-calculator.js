var _tenure = 12;
var _bulkAmountPerc = 5; //should be initialised everytime the loan type changes.
var _requiredLoanAmount;
var _rateOfInterest;
var _stepUpPerc = 0;


var _maxYAxisValue;
var _minYAxisValue;
var _stepBy = 8;

var _showLabels = false;

var _activeCalculator = "classicFinance";

function calculateEMI() {
  if (validate()) {

    $(".graph-hideshow").show();

    switch (_activeCalculator) {
      case "classicFinance":
		initSlider(_maxLoanTerm);
        calulateClassicFinanceEMI();
        break;
      case "easyFinance":
			initSlider(60);
        calulateEasyFinanceEMI();
        break;
      case "flexiFinance":
			initSlider(60);
        calulateFlexiFinanceEMI();
			
        break;
      case "smartFinance":
			initSlider(60);
        calulateSmartFinanceEMI();
			
        break;
    }
  }
}

var tenureSlider = document.getElementById("rsTenure");
var displayTenure = document.getElementById("selectedTenure");
_tenure = parseInt(tenureSlider.value);
displayTenure.innerHTML = tenureSlider.value;
tenureSlider.oninput = function () {
  displayTenure.innerHTML = this.value;
  _tenure = parseInt(this.value);
  setRateOfInterest(_tenure);
};

var balloonAmountPerc = document.getElementById("rsBalloonPerc");
var displayBalloonAmountPerc = document.getElementById("selectedBalloonPerc");
_bulkAmountPerc = parseInt(balloonAmountPerc.value);
displayBalloonAmountPerc.innerHTML = balloonAmountPerc.value;
balloonAmountPerc.oninput = function () {
  displayBalloonAmountPerc.innerHTML = this.value;
  _bulkAmountPerc = parseInt(this.value);
};

var stepUpPercSlider = document.getElementById("rsStepUpPerc");
var displayStepUpPerc = document.getElementById("selectedStepUpPerc");
_stepUpPerc = parseInt(stepUpPercSlider.value);
displayStepUpPerc.innerHTML = stepUpPercSlider.value;
stepUpPercSlider.oninput = function () {
  displayStepUpPerc.innerHTML = this.value;
  _stepUpPerc = parseInt(this.value);
};

//var bulletAmountPerc = document.getElementById("rsBulletPerc");
//var displayBulletAmountPerc = document.getElementById("selectedBulletPerc");
//_bulkAmountPerc = parseInt(bulletAmountPerc.value);
//displayBulletAmountPerc.innerHTML = bulletAmountPerc.value;
//bulletAmountPerc.oninput = function () {
//  displayBulletAmountPerc.innerHTML = this.value;
//  _bulkAmountPerc = parseInt(this.value);
//};

function setRateOfInterest(month) {
  _rateOfInterest = _tenureWiseInterestRates[month].percentage;
}

//SCROLL TO ADDRESS BLOCK
function scrollToGraph() {
  headerHeight =
    $("#divLFSHeader").innerHeight() + $("#solidMenus").innerHeight() + 30;
  $("html, body").animate(
    {
      scrollTop: $("#emiChart").offset().top - headerHeight
    },
    1000
  );
}

//Classic finance
calulateClassicFinanceEMI = function () {
  $("#lblFinanceType").text();
  $("#lblFinanceType").text("Classic Finance");

  _requiredLoanAmount = removeFormat($("#txtRequiredLoanAmount").val());
  _tenure = $("#rsTenure").val();
  var emi = PMT(_rateOfInterest / 1200, _tenure, -_requiredLoanAmount, 0, 0);
  showClassicFinanceChart(emi, _tenure);
};

showClassicFinanceChart = function (emi, tenure) {
  _maxYAxisValue = parseInt(Math.ceil(emi / 10000) * 10000);
  // _minYAxisValue = parseInt(Math.ceil((_maxYAxisValue / _stepBy) / 5000) * 1000);
  _minYAxisValue = 0;
  basicChartOptions.scales.yAxes[0].ticks.max = _maxYAxisValue;
  basicChartOptions.scales.yAxes[0].ticks.min = _minYAxisValue;

  _showLabels = false;

  var labelMonths = [];
  var dataEMI = [];
  var noOfTerms = tenure / 12;
  var initTenure = 1;

  for (var i = 1; i <= noOfTerms; i++) {
    if (tenure % 12 == 0) {
      var label = initTenure + "-" + (initTenure + 11);
      labelMonths.push(label);
      dataEMI.push(emi);
      initTenure = initTenure + 12;
    }
  }

  var chartData = {
    type: "bar",

    data: {
      labels: labelMonths,

      datasets: [
        {
          label: "EMI",

          strokeColor: "rgb(236, 29, 49)",
          highlightStroke: "rgb(236, 29, 49)",
          backgroundColor: "rgb(236, 29, 49)",
          data: dataEMI
        }
      ]
    },

    options: basicChartOptions
  };
  generateGraph(chartData);
};

//Easy finance
calulateEasyFinanceEMI = function () {


  $("#lblFinanceType").text();
  $("#lblFinanceType").text("Easy Finance");
  var initialEmi;
  _requiredLoanAmount = removeFormat($("#txtRequiredLoanAmount").val());
  _tenure = $("#rsTenure").val();
  var rateOfInterest = _rateOfInterest / 1200;

  var stepUpPer = _stepUpPerc / 100,
    moratorium = 0,
    tempTenure = moratorium,
    varX = 0,
    varY = 0,
    varZ = 100;


  if (stepUpPer > 0) {
    nominator = _requiredLoanAmount * Math.pow(1 + rateOfInterest, _tenure - moratorium);
    do {
      varX += Math.pow(
        1 + rateOfInterest,
        _tenure - tempTenure - 1 - moratorium
      );

      tempTenure++;
      if (tempTenure % 12 == 0 && tempTenure != 0) {
        varY += (varZ / 100) * varX;

        varZ += varZ * stepUpPer;

        varX = 0;
      }
    } while (tempTenure < _tenure);
    initialEmi = nominator / varY;
  } else {
    initialEmi = PMT(
      rateOfInterest,
      _tenure - moratorium,
      -_requiredLoanAmount * Math.pow(1 + rateOfInterest, moratorium),
      0,
      0
    );
  }
  if (!isNaN(initialEmi)) {
    if (initialEmi < 0) {
      initialEmi = 0;
    }
  }

  console.log(rateOfInterest);
  console.log(initialEmi)
  showEasyFinanceChart(initialEmi, _tenure);
};

showEasyFinanceChart = function (initialEmi, tenure) {
  var labelMonths = [];
  var dataEMI = [];
  var noOfTerms = tenure / 12;
  var initTenure = 1;
  var emi = initialEmi;

  _showLabels = true;

  for (var i = 1; i <= noOfTerms; i++) {
    if (tenure % 12 == 0) {
      if (_stepUpPerc != 0) {
        if (i != 1) {
          emi += emi * (_stepUpPerc / 100);
        }
      }
      var label = initTenure + "-" + (initTenure + 11);
      labelMonths.push(label);
      dataEMI.push(emi);

      initTenure = initTenure + 12;
    }
  }
  console.log(dataEMI);
  // console.log(dataEMI[dataEMI.length-1]);

  _maxYAxisValue = parseInt(Math.ceil(dataEMI[dataEMI.length - 1] / 10000) * 10000);
  _minYAxisValue = parseInt(Math.floor((_maxYAxisValue / _stepBy) / 5000) * 5000);

  basicChartOptions.scales.yAxes[0].ticks.max = _maxYAxisValue;
  basicChartOptions.scales.yAxes[0].ticks.min = _minYAxisValue;

  var chartData = {
    type: "bar",
    data: {
      labels: labelMonths,
      datasets: [
        {
          label: "EMI",
          strokeColor: "rgb(236, 29, 49)",
          highlightStroke: "rgb(236, 29, 49)",
          backgroundColor: "rgb(236, 29, 49)",
          data: dataEMI
        }
      ]
    },
    options: basicChartOptions
  };
  console.log(chartData);
  generateGraph(chartData);
};




//Flexi finance(Bulltet)
calulateFlexiFinanceEMI = function () {
  $("#lblFinanceType").text();
  $("#lblFinanceType").text("Flexi Finance");
  _tenure = $("#rsTenure").val();
  var emi;
  _requiredLoanAmount = parseFloat(removeFormat(document.getElementById("txtRequiredLoanAmount").value));
  var bulletTenure = _tenure / 12;
  if(bulletTenure < 1) bulletTenure = 1;

  // var bulkAmount = Math.round(parseFloat((_requiredLoanAmount * (_bulkAmountPerc / 100)/bulletTenure)));
  var fixedBulkAmountPerc = 40;
  var bulkAmount = Math.round(parseFloat((_requiredLoanAmount * (fixedBulkAmountPerc / 100)/bulletTenure)));
  var tempTenure = _tenure - bulletTenure;
  
 console.clear();
  var interestRates = {
    "m12": {
      "bullet30": {
        "roi": "8.9",
        "consta": "-0.731"
      },
      "bullet40": {
        "roi": "9",
        "consta": "-0.746"
      }
    },
    "m24": {
      "bullet30": {
        "roi": "10.01",
        "consta": "2.317"
      },
      "bullet40": {
        "roi": "9",
        "consta": "2.45"
      }
    },
    "m36": {
      "bullet30": {
        "roi": "9",
        "consta": "4.985"
      },
      "bullet40": {
        "roi": "9",
        "consta": "5.75"
      }
    },
    "m48": {
      "bullet30": {
        "roi": "10",
        "consta": "8.81"
      },
      "bullet40": {
        "roi": "9",
        "consta": "9.20"
      }
    },
    "m60": {
      "bullet30": {
        "roi": "10",
        "consta": "12.03"
      },
      "bullet40": {
        "roi": "9",
        "consta": "12.63"
      }
    },
    "m72": {
      "bullet30": {
        "roi": "10",
        "consta": "15.34"
      },
      "bullet40": {
        "roi": "9",
        "consta": "16.35"
      }
    },
    "m84": {
      "bullet30": {
        "roi": "10",
        "consta": "18.8"
      },
      "bullet40": {
        "roi": "9",
        "consta": "20.15"
      }
    }
  }

  var tempRoi, constaVal, tempBulkAmount;
  var fixedBulkAmountPointer = 'bullet' + fixedBulkAmountPerc;
  for (key in interestRates) {
    if ('m' + _tenure == key) {
          var bulletObj = interestRates[key];    
          tempRoi = parseFloat(bulletObj[fixedBulkAmountPointer].roi);
          console.log("tempConsta: " + bulletObj[fixedBulkAmountPointer].consta);
          constaVal = _rateOfInterest * bulletObj[fixedBulkAmountPointer].consta/tempRoi;
          console.log("consta value: " + constaVal);
          console.log("tempRoi: " + tempRoi);
          tempBulkAmount = ((bulkAmount * constaVal)/100) + bulkAmount;
          console.log("temp bulk amount: " + tempBulkAmount);     
    }
  }
  
  var fv = parseFloat(tempBulkAmount * bulletTenure);

  emi = PMT(_rateOfInterest / 1200, tempTenure, -_requiredLoanAmount,fv,0);
  console.log("EMI: " + emi);
  console.log("BULK AMOUNT: " + bulkAmount);
  showFlexiFinanceChart(emi, bulkAmount, _tenure);
};

showFlexiFinanceChart = function (emi, bulkAmount, tenure) {
  var labelMonths = [];
  var dataEMI = [];
  var noOfTerms = tenure / 12;
  var initTenure = 1;
  // var bulletAmount = bulkAmount / noOfTerms;
  var bulletAmount = bulkAmount;
  var TotalEmitAmount = bulletAmount;

  var maxValue = (TotalEmitAmount > emi) ? TotalEmitAmount : emi;

  _showLabels = false;

  _maxYAxisValue = parseInt(Math.ceil(maxValue / 10000) * 10000);
  _minYAxisValue = parseInt(Math.floor((emi / _stepBy) / 5000) * 5000);

  basicChartOptions.scales.yAxes[0].ticks.max = _maxYAxisValue;
  basicChartOptions.scales.yAxes[0].ticks.min = _minYAxisValue;



  for (var i = 1; i <= noOfTerms; i++) {
    var label = initTenure + "-" + (initTenure + 10);

    labelMonths.push(label);
    dataEMI.push(emi);

    initTenure = initTenure + 11;
    if (initTenure % 12 == 0) {
      labelMonths.push(initTenure);
      dataEMI.push(TotalEmitAmount);

    }
    initTenure += 1;
  }
  var chartData = {
    type: "bar",
    data: {
      labels: labelMonths,
      datasets: [
        {
          label: "EMI",
          strokeColor: "rgb(236, 29, 49)",
          highlightStroke: "rgb(236, 29, 49)",
          backgroundColor: "rgb(236, 29, 49)",
          data: dataEMI
        }


      ]
    },
    options: basicChartOptions
  };
  generateGraph(chartData);
};

//Smart finance(Balloon)
calulateSmartFinanceEMI = function () {
  $("#lblFinanceType").text();
  $("#lblFinanceType").text("Smart Finance");
  _requiredLoanAmount = removeFormat($("#txtRequiredLoanAmount").val());
  _tenure = $("#rsTenure").val();


  var balloonAmount = parseFloat(_requiredLoanAmount * (_bulkAmountPerc / 100));
  actualLoanAmount = _requiredLoanAmount - balloonAmount;
  actualTenure = _tenure - 1;
  console.log("Req Loan: " + _requiredLoanAmount);
  console.log("_tenure: " + _tenure);
  console.log("balloon Amount: " + balloonAmount);
  console.log("act loan amount: " + actualLoanAmount);
  console.log("act tenure: " + actualTenure);
  var emi = PMT(_rateOfInterest / 1200, actualTenure, -_requiredLoanAmount, balloonAmount, 0);
  
  var ballonAmountInterest = Math.round((balloonAmount * _rateOfInterest)/1200);

  // distribute balloon interest amount among emis throught tenure.
  // this shows balloon amount exactly as the selected balloon percentage on the graph.
  console.log(emi);
  console.log(_tenure);
  emi += Math.round(ballonAmountInterest/_tenure);
  console.log("final emi:" + emi);
  showSmartFinanceChart(emi, balloonAmount,ballonAmountInterest, _tenure);
};

showSmartFinanceChart = function (emi, balloonAmount,ballonAmountInterest, tenure) {
  var labelMonths = [];
  var dataEMI = [];

  var noOfTerms = tenure / 12;
  var initTenure = 1;
 // balloonAmount = balloonAmount + ballonAmountInterest;
  balloonAmount = balloonAmount;

  var maxValue = (balloonAmount > emi) ? balloonAmount : emi;
  _showLabels = false;

  _maxYAxisValue = parseInt(Math.ceil(maxValue / 10000) * 10000);
  _minYAxisValue = parseInt(Math.floor((emi / _stepBy) / 5000) * 5000);

  basicChartOptions.scales.yAxes[0].ticks.max = _maxYAxisValue;
  basicChartOptions.scales.yAxes[0].ticks.min = _minYAxisValue;


  for (var i = 1; i <= noOfTerms; i++) {
    if (tenure % 12 == 0) {
      var label;
      if (i == noOfTerms) {
        label = initTenure + "-" + (initTenure + 10);
      } else {
        label = initTenure + "-" + (initTenure + 11);
      }

      labelMonths.push(label);
      dataEMI.push(emi);
      initTenure = initTenure + 12;

      if (i == noOfTerms) {
        dataEMI.push(balloonAmount);

        labelMonths.push(tenure);
      } else {
      }
    }
  }

  var chartData = {
    type: "bar",
    data: {
      labels: labelMonths,

      datasets: [
        {
          label: "EMI",

          strokeColor: "rgba(236, 29, 49, 0.3)",
          highlightStroke: "rgba(236, 29, 49,1)",
          backgroundColor: "rgb(236, 29, 49)",
          data: dataEMI
        }
      ]
    },
    options: basicChartOptions
  };
  generateGraph(chartData);
};

//COMMON CHART FUNCTIONS

var basicChartOptions = {
  tooltips: {
    enabled: true,
    callbacks: {
      label: function (t, d) {
        var xLabel = d.datasets[t.datasetIndex].label;
        var yLabel = "Rs." + toIndianFormat(t.yLabel);
        return xLabel + ": " + yLabel;
      }
    }
  },
  hover: {
    animationDuration: 1
  },
  animation: {
    duration: 3000,
    animation: true,
    animationSteps: 60,
    onComplete: function () {
      var chartInstance = this.chart,
        ctx = chartInstance.ctx;
      ctx.textAlign = "center";
      ctx.fillStyle = "rgba(0, 0, 0, 1)";
      ctx.textBaseline = "bottom";

      this.data.datasets.forEach(function (dataset, i) {
        var meta = chartInstance.controller.getDatasetMeta(i);
        meta.data.forEach(function (bar, index) {
          var data = dataset.data[index];
          if (isMobile) {
            if (_showLabels) {
              ctx.fillText(
                "Rs." + toIndianFormat(data),
                bar._model.x,
                bar._model.y - 5
              );
            }
          } else {
            ctx.fillText(
              "Rs." + toIndianFormat(data),
              bar._model.x,
              bar._model.y - 5
            );
          }
        });
      });
    }
  },
  legend: {
    onClick: e => e.stopPropagation(),
    padding: 1
  },
  responsive: true,
  maintainAspectRatio: false,
  scales: {
    xAxes: [
      {
        stacked: false,
        barPercentage: 0.3,
        ticks: {
          beginAtZero: true
        },
        gridLines: {
          display: false
        }
      }
    ],
    yAxes: [
      {

        ticks: {
          beginAtZero: false,

          // stepSize: _minYAxisValue,

          max: _maxYAxisValue,
          min: _minYAxisValue,

          callback: function (value, index, values) {
            if (parseInt(value) >= 1000) {
              return "Rs." + toIndianFormat(value);
            } else {
              return "Rs." + toIndianFormat(value);
            }
          }
        },
        stacked: false,
        display: true
      }
    ]
  }
};

var stackedChartOptions = {
  tooltips: {
    enabled: true,
    callbacks: {
      label: function (t, d) {
        var xLabel = d.datasets[t.datasetIndex].label;
        var yLabel = "Rs." + toIndianFormat(t.yLabel);
        return xLabel + ": " + yLabel;
      }
    }
  },
  hover: {
    animationDuration: 1
  },

  animation: {
    duration: 3000,
    animation: true,
    animationSteps: 60,
    onComplete: function () {
      var chartInstance = this.chart,
        ctx = chartInstance.ctx;
      ctx.textAlign = "center";
      ctx.fillStyle = "rgba(0, 0, 0, 1)";
      ctx.textBaseline = "bottom";

      this.data.datasets.forEach(function (dataset, i) {
        var meta = chartInstance.controller.getDatasetMeta(i);
        meta.data.forEach(function (bar, index) {
          var data = dataset.data[index];
          if (data != null) data = "Rs." + toIndianFormat(parseFloat(data));
          ctx.fillText(data, bar._model.x, bar._model.y - 5);
        });
      });
    }
  },
  legend: {
    onClick: e => e.stopPropagation()
  },
  responsive: true,
  maintainAspectRatio: false,
  scales: {
    xAxes: [
      {
        stacked: true,
        barPercentage: 0.3,
        ticks: {
          beginAtZero: true
        },
        gridLines: {
          display: false
        }
      }
    ],
    yAxes: [
      {
        ticks: {
          callback: function (value, index, values) {
            if (parseInt(value) >= 1000) {
              return "Rs." + toIndianFormat(value);
            } else {
              return "Rs." + toIndianFormat(value);
            }
          }
        },
        stacked: true,
        display: true
      }
    ]
  }
};

var EMIChart;
generateGraph = function (chartData) {
  if (EMIChart) EMIChart.destroy();
  var canvas = document.getElementById("emiChart").getContext("2d");
  EMIChart = new Chart(canvas, chartData);
  scrollToGraph();
};

clearGraph = function () {
  if (EMIChart != null) {
    EMIChart.destroy();
  }
};

function workerIRR(cfs, values, fv) {
  if (typeof fv === "undefined") {
    fv = 0;
  }
  var rate = 0.0001,
    currentNPV = cfs;
  do {
    var npv = cfs;
    // base case
    for (var i = 0; i < values.length; i++) {
      npv += values[i] / Math.pow(1 + rate / 100, i + 1);
    }
    currentNPV = Math.round(npv * 100) / 100;
    rate += 0.0001;
  } while (currentNPV > fv);

  return rate.toFixed(4);
}

function PMT(rate, noOfPayments, loanAmount, futureValue, type) {
  if (rate != 0.0) {
    // Interest rate exists
    var q = Math.pow(1 + rate, noOfPayments);
    return (
      -(rate * (futureValue + q * loanAmount)) / ((-1 + q) * (1 + rate * type))
    );
  } else if (noOfPayments != 0.0) {
    // No interest rate, but number of payments exists
    return -(futureValue + loanAmount) / noOfPayments;
  }

  return 0;
}

function PMT1(rate, noOfPayments, loanAmount, futureValue, type) {
  if (rate != 0.0) {
    // Interest rate exists
    var q = Math.pow(1 + rate, noOfPayments - 1);
    return (
      -(rate * (futureValue + q * loanAmount)) / ((-1 + q) * (1 + rate * type))
    );
  } else if (noOfPayments != 0.0) {
    // No interest rate, but number of payments exists
    return -(futureValue + loanAmount) / noOfPayments;
  }

  return 0;
}

function PV(rate, nper, pmt, fv, type) {
  if (rate == 0.0) return -fv - pmt * nper;
  else
    return (
      ((pmt * (1.0 + rate * type) * (1.0 - Math.pow(1.0 + rate, nper))) / rate -
        fv) /
      Math.pow(1.0 + rate, nper)
    );
}

function FV(rate, pv, noOfPayments) {
  return pv * Math.pow(1 + r, noOfPayments);
}

//Utils

function removeFormat(val) {
  if (typeof val === "undefined" || val === null || val == "--" || val == "") {
    val = 0;
  }
  return parseFloat(
    val
      .toString()
      .replace("Rs.", "")
      .replace(/,/g, "")
      .replace("Rs.", "")
  );
}

function toIndianFormat(val) {
  if (typeof val === "undefined" || isNaN(val)) {
    val = 0;
  }
  val = val.toString();
  var afterPoint = ".00";

  val = Math.ceil(val);
  val = val.toString();

  var lastThree = val.substring(val.length - 3);
  var otherNumbers = val.substring(0, val.length - 3);

  if (otherNumbers != "") lastThree = "," + lastThree;

  var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;
  return res;
}

function amountInWords(amount) {
  amount = Math.floor(amount);
  var obStr = new String(amount);
  numReversed = obStr.split("");
  actnumber = numReversed.reverse();

  if (Number(amount) >= 0) {
    //do nothing
  } else {
    alert("wrong Number cannot be converted");
    return false;
  }
  if (Number(amount) == 0) {
    return "Rupees Zero Only";
  }
  if (actnumber.length > 9) {
    alert("Oops!!!! the Number is too big to covert");
    return false;
  }

  var iWords = [
    "Zero",
    " One",
    " Two",
    " Three",
    " Four",
    " Five",
    " Six",
    " Seven",
    " Eight",
    " Nine"
  ];
  var ePlace = [
    "Ten",
    " Eleven",
    " Twelve",
    " Thirteen",
    " Fourteen",
    " Fifteen",
    " Sixteen",
    " Seventeen",
    " Eighteen",
    " Nineteen"
  ];
  var tensPlace = [
    "dummy",
    " Ten",
    " Twenty",
    " Thirty",
    " Forty",
    " Fifty",
    " Sixty",
    " Seventy",
    " Eighty",
    " Ninety"
  ];

  var iWordsLength = numReversed.length;
  var totalWords = "";
  var inWords = new Array();
  var finalWord = "";
  j = 0;
  for (i = 0; i < iWordsLength; i++) {
    switch (i) {
      case 0:
        if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
          inWords[j] = "";
        } else {
          inWords[j] = iWords[actnumber[i]];
        }
        inWords[j] = inWords[j] + " Only";
        break;
      case 1:
        tens_complication();
        break;
      case 2:
        if (actnumber[i] == 0) {
          inWords[j] = "";
        } else if (actnumber[i - 1] != 0 && actnumber[i - 2] != 0) {
          inWords[j] = iWords[actnumber[i]] + " Hundred and";
        } else {
          inWords[j] = iWords[actnumber[i]] + " Hundred";
        }
        break;
      case 3:
        if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
          inWords[j] = "";
        } else {
          inWords[j] = iWords[actnumber[i]];
        }
        if (actnumber[i + 1] != 0 || actnumber[i] > 0) {
          inWords[j] = inWords[j] + " Thousand";
        }
        break;
      case 4:
        tens_complication();
        break;
      case 5:
        if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
          inWords[j] = "";
        } else {
          inWords[j] = iWords[actnumber[i]];
        }
        if (actnumber[i + 1] != 0 || actnumber[i] > 0) {
          inWords[j] = inWords[j] + " Lakh";
        }
        break;
      case 6:
        tens_complication();
        break;
      case 7:
        if (actnumber[i] == 0 || actnumber[i + 1] == 1) {
          inWords[j] = "";
        } else {
          inWords[j] = iWords[actnumber[i]];
        }
        inWords[j] = inWords[j] + " Crore";
        break;
      case 8:
        tens_complication();
        break;
      default:
        break;
    }
    j++;
  }

  function tens_complication() {
    if (actnumber[i] == 0) {
      inWords[j] = "";
    } else if (actnumber[i] == 1) {
      inWords[j] = ePlace[actnumber[i - 1]];
    } else {
      inWords[j] = tensPlace[actnumber[i]];
    }
  }
  inWords.reverse();
  for (i = 0; i < inWords.length; i++) {
    finalWord += inWords[i];
  }
  return finalWord;
}
