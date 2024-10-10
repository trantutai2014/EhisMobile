import { Component, OnInit } from '@angular/core';
import { UserRoleService } from './user-role.service';


@Component({
  selector: 'app-user-role',
  templateUrl: './user-role.component.html',
  styleUrls: ['./user-role.component.html']
})
export class UserRoleComponent implements OnInit {
  userRoles: any[] = [];
  loading: boolean = false;
  error: string | null = null;

  constructor(private userRoleService: UserRoleService) {}

  ngOnInit(): void {
    this.getUserRoles();
  }

  getUserRoles(): void {
    this.loading = true;
    this.userRoleService.getUserRoles().subscribe({
      next: (roles) => {
        this.userRoles = roles;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load user roles';
        this.loading = false;
      }
    });
  }
}
