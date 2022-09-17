import React, { FC } from 'react';
import styles from './FloorPlan.module.css';

interface FloorPlanProps {}

const FloorPlan: FC<FloorPlanProps> = () => (
  <div className={styles.FloorPlan} data-testid="FloorPlan">
    FloorPlan Component
  </div>
);

export default FloorPlan;
