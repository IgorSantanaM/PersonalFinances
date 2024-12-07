import React from 'react';
import {  Routes, Route } from 'react-router-dom';

import Home from './pages/Home';
import Balance from './pages/Balance';
import Summary from './pages/Summary';
import Movement from './pages/Movement';
import Calendar from './pages/Calendar';
import Menu from './pages/Menu';
import StepAccount from './pages/steps/Account';
import StepCategory from './pages/steps/Category';
import StepReminder from './pages/steps/Reminder';

export default function RoutesConfig() {
  return (
      <Routes>
        <Route path="/" exact element={<Home />} />
        <Route path="/balance" exact element={<Balance />} />
        <Route path="/summary" exact element={<Summary />} />
        <Route path="/movement" exact element={<Movement />} />
        <Route path="/calendar" exact element={<Calendar />} />
        <Route path="/menu" exact element={<Menu />} />
        <Route path="/step/account" exact element={<StepAccount />} />
        <Route path="/step/category" exact element={<StepCategory />} />
        <Route path="/step/reminder" exact element={<StepReminder />} />

        {/* TODO: more pages */}
      </Routes>
  );
}
