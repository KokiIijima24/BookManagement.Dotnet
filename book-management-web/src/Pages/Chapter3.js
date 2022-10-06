import React from 'react'

const onesecond = () => 1000
const getCurrentTime = () => new Date()
const clear = () => console.clear()
const log = (message) => console.log(message)

function compose(f, g) {
  return function (...args) {
    return f(g(...args))
  }
}

function composeAll(...fns) {
  return fns.reduce(compose) // return function is (...args) => f(g(h(j(k(...args)))))
}

const serializeClockTime = (date) => ({
  hours: date.getHours(),
  minuites: date.getMinutes(),
  seconds: date.getSeconds(),
})

const civilianHours = (clockTime) => ({
  ...clockTime,
  hours: clockTime.hours > 12 ? clockTime.hours - 12 : clockTime.hours,
})

const display = (target) => (time) => target(time)

const formatClock = (format) => (time) =>
  format
    .replace('hh', time.hours)
    .replace('mm', time.minuites)
    .replace('ss', time.seconds)
    .replace('tt', time.ampm)

const prependZero = (key) => (clockTime) => ({
  ...clockTime,
  [key]: clockTime[key] < 10 ? '0' + clockTime[key] : '' + clockTime[key],
})

const appendAMPM = (clockTime) => ({
  ...clockTime,
  ampm: clockTime.hours >= 12 ? 'PM' : 'AM',
})

const doubleDigits = civilianTime => (
  composeAll(
    prependZero("hours"),
    prependZero("minuites"),
    prependZero("seconds")
  )(civilianTime)
)

const convertToCivilianTime = (clockTime) =>
  composeAll(appendAMPM, civilianHours)(clockTime)

function Chapter3() {
  composeAll(
    display(log),
    formatClock("hh:mm:ss tt"),
    doubleDigits,
    convertToCivilianTime,
    serializeClockTime,
    getCurrentTime,
    clear
  )()

  return (
    <div>
      <div>chapter3</div>
      <div></div>
    </div>
  )
}

export default Chapter3
