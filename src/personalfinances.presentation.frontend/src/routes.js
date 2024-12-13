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
import Account from './pages/Account'

export default function RoutesConfig() {
  return (
      <Routes>
        <Route path="/" exact element={<Home />} />
        <Route path="/balance" element={<Balance />} />
        <Route path="/summary" element={<Summary />} />
        <Route path="/movement" element={<Movement />} />
        <Route path="/calendar" element={<Calendar />} />
        <Route path="/menu" element={<Menu />} />
        <Route path="/step/account" element={<StepAccount />} />
        <Route path="/step/category" element={<StepCategory />} />
        <Route path="/step/reminder" element={<StepReminder />} />
        <Route path="/account" element={<Account />} />
        {/* TODO: more pages */}
      </Routes>
  );
}
